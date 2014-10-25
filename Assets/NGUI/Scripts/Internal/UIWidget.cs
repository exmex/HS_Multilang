//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2013 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Base class for all UI components that should be derived from when creating new widget types.
/// </summary>

public abstract class UIWidget : MonoBehaviour
{
	public enum Pivot
	{
		TopLeft,
		Top,
		TopRight,
		Left,
		Center,
		Right,
		BottomLeft,
		Bottom,
		BottomRight,
	}

	// Cached and saved values
	[HideInInspector][SerializeField] protected Material mMat;
	[HideInInspector][SerializeField] protected Texture mTex;
	[HideInInspector][SerializeField] Color mColor = Color.white;
	[HideInInspector][SerializeField] Pivot mPivot = Pivot.Center;
	[HideInInspector][SerializeField] int mDepth = 0;
	protected Transform mTrans;
	protected UIPanel mPanel;

	protected bool mChanged = true;
	protected bool mPlayMode = true;

	GameObject mGo;
	Vector3 mDiffPos;
	Quaternion mDiffRot;
	Vector3 mDiffScale;
	int mVisibleFlag = -1;

	// Widget's generated geometry
	UIGeometry mGeom = new UIGeometry();

	/// <summary>
	/// Whether the widget is visible.
	/// </summary>

	public bool isVisible { get { return finalAlpha > 0.001f; } }

	/// <summary>
	/// Color used by the widget.
	/// </summary>

	public Color color { get { return mColor; } set { if (!mColor.Equals(value)) { mColor = value; mChanged = true; } } }

	/// <summary>
	/// Widget's alpha -- a convenience method.
	/// </summary>

	public float alpha { get { return mColor.a; } set { Color c = mColor; c.a = value; color = c; } }

	/// <summary>
	/// Widget's final alpha, after taking the panel's alpha into account.
	/// </summary>

	public float finalAlpha { get { if (mPanel == null) CreatePanel(); return (mPanel != null) ? mColor.a * mPanel.alpha : mColor.a; } }

	/// <summary>
	/// Set or get the value that specifies where the widget's pivot point should be.
	/// </summary>

	public Pivot pivot
	{
		get
		{
			return mPivot;
		}
		set
		{
			if (mPivot != value)
			{
				Vector3 before = NGUIMath.CalculateWidgetCorners(this)[0];

				mPivot = value;
				mChanged = true;

				Vector3 after = NGUIMath.CalculateWidgetCorners(this)[0];

				Transform t = cachedTransform;
				Vector3 pos = t.position;
				float z = t.localPosition.z;
				pos.x += (before.x - after.x);
				pos.y += (before.y - after.y);
				cachedTransform.position = pos;

				pos = cachedTransform.localPosition;
				pos.x = Mathf.Round(pos.x);
				pos.y = Mathf.Round(pos.y);
				pos.z = z;
				cachedTransform.localPosition = pos;
			}
		}
	}
	
	/// <summary>
	/// Depth controls the rendering order -- lowest to highest.
	/// </summary>

	public int depth { get { return mDepth; } set { if (mDepth != value) { mDepth = value; if (mPanel != null) mPanel.MarkMaterialAsChanged(material, true); } } }

	/// <summary>
	/// Helper function that calculates the relative offset based on the current pivot.
	/// </summary>

	public Vector2 pivotOffset
	{
		get
		{
			Vector2 v = Vector2.zero;
			Vector4 p = relativePadding;

			Pivot pv = pivot;

			if (pv == Pivot.Top || pv == Pivot.Center || pv == Pivot.Bottom) v.x = (p.x - p.z - 1f) * 0.5f;
			else if (pv == Pivot.TopRight || pv == Pivot.Right || pv == Pivot.BottomRight) v.x = -1f - p.z;
			else v.x = p.x;

			if (pv == Pivot.Left || pv == Pivot.Center || pv == Pivot.Right) v.y = (p.w - p.y + 1f) * 0.5f;
			else if (pv == Pivot.BottomLeft || pv == Pivot.Bottom || pv == Pivot.BottomRight) v.y = 1f + p.w;
			else v.y = -p.y;

			return v;
		}
	}

	/// <summary>
	/// Transform gets cached for speed.
	/// </summary>

	public Transform cachedTransform { get { if (mTrans == null) mTrans = transform; return mTrans; } }

	/// <summary>
	/// Returns the material used by this widget.
	/// </summary>

	public virtual Material material
	{
		get
		{
			return mMat;
		}
		set
		{
			if (mMat != value)
			{
				if (mMat != null && mPanel != null) mPanel.RemoveWidget(this);

				mPanel = null;
				mMat = value;
				mTex = null;

				if (mMat != null) CreatePanel();
			}
		}
	}

	/// <summary>
	/// Returns the texture used to draw this widget.
	/// </summary>

	public virtual Texture mainTexture
	{
		get
		{
			// If the material has a texture, always use it instead of 'mTex'.
			Material mat = material;
			
			if (mat != null)
			{
				if (mat.mainTexture != null)
				{
					mTex = mat.mainTexture;
				}
				else if (mTex != null)
				{
					// The material has no texture, but we have a saved texture
					if (mPanel != null) mPanel.RemoveWidget(this);

					// Set the material's texture to the saved value
					mPanel = null;
					mMat.mainTexture = mTex;

					// Ensure this widget gets added to the panel
					if (enabled) CreatePanel();
				}
			}
			return mTex;
		}
		set
		{
			Material mat = material;

			if (mat == null || mat.mainTexture != value)
			{
				if (mPanel != null) mPanel.RemoveWidget(this);

				mPanel = null;
				mTex = value;
				mat = material;

				if (mat != null)
				{
					mat.mainTexture = value;
					if (enabled) CreatePanel();
				}
			}
		}
	}

	/// <summary>
	/// Returns the UI panel responsible for this widget.
	/// </summary>

	public UIPanel panel { get { if (mPanel == null) CreatePanel(); return mPanel; } set { mPanel = value; } }

	/// <summary>
	/// Flag set by the UIPanel and used in optimization checks.
	/// </summary>

	public int visibleFlag { get { return mVisibleFlag; } set { mVisibleFlag = value; } }

	/// <summary>
	/// Raycast into the screen and return a list of widgets in order from closest to farthest away.
	/// This is a slow operation and will consider ALL widgets underneath the specified game object.
	/// </summary>

	static public BetterList<UIWidget> Raycast (GameObject root, Vector2 mousePos)
	{
		BetterList<UIWidget> list = new BetterList<UIWidget>();
		UICamera uiCam = UICamera.FindCameraForLayer(root.layer);

		if (uiCam != null)
		{
			Camera cam = uiCam.cachedCamera;
			UIWidget[] widgets = root.GetComponentsInChildren<UIWidget>();

			for (int i = 0; i < widgets.Length; ++i)
			{
				UIWidget w = widgets[i];

				Vector3[] corners = NGUIMath.CalculateWidgetCorners(w);
				if (NGUIMath.DistanceToRectangle(corners, mousePos, cam) == 0f)
					list.Add(w);
			}

			list.Sort(delegate(UIWidget w1, UIWidget w2) { return w2.depth.CompareTo(w1.depth); });
		}
		return list;
	}

	/// <summary>
	/// Static widget comparison function used for Z-sorting.
	/// </summary>

	static public int CompareFunc (UIWidget left, UIWidget right)
	{
		if (left.mDepth > right.mDepth) return 1;
		if (left.mDepth < right.mDepth) return -1;
		return 0;
	}

	/// <summary>
	/// Only sets the local flag, does not notify the panel.
	/// In most cases you will want to use MarkAsChanged() instead.
	/// </summary>

	public void MarkAsChangedLite () { mChanged = true; }

	/// <summary>
	/// Tell the panel responsible for the widget that something has changed and the buffers need to be rebuilt.
	/// </summary>

	public virtual void MarkAsChanged ()
	{
		mChanged = true;

		// If we're in the editor, update the panel right away so its geometry gets updated.
		if (mPanel != null && enabled && NGUITools.GetActive(gameObject) && !Application.isPlaying && material != null)
		{
			mPanel.AddWidget(this);
			CheckLayer();
#if UNITY_EDITOR
			// Mark the panel as dirty so it gets updated
			UnityEditor.EditorUtility.SetDirty(mPanel.gameObject);
#endif
		}
	}

	/// <summary>
	/// Ensure we have a panel referencing this widget.
	/// </summary>

	public void CreatePanel ()
	{
		if (mPanel == null && enabled && NGUITools.GetActive(gameObject) && material != null)
		{
			mPanel = UIPanel.Find(cachedTransform);

			if (mPanel != null)
			{
				CheckLayer();
				mPanel.AddWidget(this);
				mChanged = true;
			}
		}
	}

	/// <summary>
	/// Check to ensure that the widget resides on the same layer as its panel.
	/// </summary>

	public void CheckLayer ()
	{
		if (mPanel != null && mPanel.gameObject.layer != gameObject.layer)
		{
			Debug.LogWarning("You can't place widgets on a layer different than the UIPanel that manages them.\n" +
				"If you want to move widgets to a different layer, parent them to a new panel instead.", this);
			gameObject.layer = mPanel.gameObject.layer;
		}
	}

	/// <summary>
	/// For backwards compatibility. Use ParentHasChanged() instead.
	/// </summary>

	[System.Obsolete("Use ParentHasChanged() instead")]
	public void CheckParent () { ParentHasChanged(); }

	/// <summary>
	/// Checks to ensure that the widget is still parented to the right panel.
	/// </summary>

	public void ParentHasChanged ()
	{
		if (mPanel != null)
		{
			// This code allows drag & dropping of widgets onto different panels in the editor.
			bool valid = true;
			Transform t = cachedTransform.parent;

			// Run through the parents and see if this widget is still parented to the transform
			while (t != null)
			{
				if (t == mPanel.cachedTransform) break;
				if (!mPanel.WatchesTransform(t)) { valid = false; break; }
				t = t.parent;
			}

			// This widget is no longer parented to the same panel. Remove it and re-add it to a new one.
			if (!valid)
			{
				if (!keepMaterial || Application.isPlaying) material = null;
				mPanel = null;
				CreatePanel();
			}
		}
	}

	/// <summary>
	/// Remember whether we're in play mode.
	/// </summary>

	protected virtual void Awake () { mGo = gameObject; mPlayMode = Application.isPlaying; }

	/// <summary>
	/// Mark the widget and the panel as having been changed.
	/// </summary>

	protected virtual void OnEnable ()
	{
#if UNITY_EDITOR
		if (GetComponents<UIWidget>().Length > 1)
		{
			Debug.LogError("Can't have more than one widget on the same game object!", this);
			enabled = false;
		}
		else
#endif
		{
			mChanged = true;

			if (!keepMaterial)
			{
				mMat = null;
				mTex = null;
			}
			mPanel = null;
		}
	}

	/// <summary>
	/// Set the depth, call the virtual start function, and sure we have a panel to work with.
	/// </summary>

	void Start ()
	{
		OnStart();
		CreatePanel();
	}

	/// <summary>
	/// Ensure that we have a panel to work with. The reason the panel isn't added in OnEnable()
	/// is because OnEnable() is called right after Awake(), which is a problem when the widget
	/// is brought in on a prefab object as it happens before it gets parented.
	/// </summary>

	public void Update ()
	{
		CheckLayer();

		// Ensure we have a panel to work with by now
		if (mPanel == null) CreatePanel();
#if UNITY_EDITOR
		else if (!Application.isPlaying) ParentHasChanged();
#endif
		
		// Automatically reset the Z scaling component back to 1 as it's not used
		Vector3 scale = cachedTransform.localScale;

		if (scale.z != 1f)
		{
			scale.z = 1f;
			mTrans.localScale = scale;
		}
	}

	/// <summary>
	/// Clear references.
	/// </summary>

	void OnDisable ()
	{
		if (!keepMaterial)
		{
			material = null;
		}
		else if (mPanel != null)
		{
			mPanel.RemoveWidget(this);
		}
		mPanel = null;
	}

	/// <summary>
	/// Unregister this widget.
	/// </summary>

	void OnDestroy ()
	{
		if (mPanel != null)
		{
			mPanel.RemoveWidget(this);
			mPanel = null;
		}
	}

#if UNITY_EDITOR

	static int mHandles = -1;

	/// <summary>
	/// Whether widgets will show handles with the Move Tool, or just the View Tool.
	/// </summary>

	static public bool showHandlesWithMoveTool
	{
		get
		{
			if (mHandles == -1)
			{
				mHandles = UnityEditor.EditorPrefs.GetInt("NGUI Handles", 1);
			}
			return (mHandles == 1);
		}
		set
		{
			int val = value ? 1 : 0;

			if (mHandles != val)
			{
				mHandles = val;
				UnityEditor.EditorPrefs.SetInt("NGUI Handles", mHandles);
			}
		}
	}

	/// <summary>
	/// Whether handles should be shown around the widget for easy scaling and resizing.
	/// </summary>

	static public bool showHandles
	{
		get
		{
			if (showHandlesWithMoveTool)
			{
				return UnityEditor.Tools.current == UnityEditor.Tool.Move;
			}
			return UnityEditor.Tools.current == UnityEditor.Tool.View;
		}
	}

	/// <summary>
	/// Draw some selectable gizmos.
	/// </summary>

	void OnDrawGizmos ()
	{
		if (mVisibleFlag != 0 && mPanel != null && mPanel.debugInfo == UIPanel.DebugInfo.Gizmos)
		{
			if (UnityEditor.Selection.activeGameObject == gameObject && showHandles) return;

			Color outline = new Color(1f, 1f, 1f, 0.2f);

			// Position should be offset by depth so that the selection works properly
			Vector3 pos = Vector3.zero;
			pos.z -= mDepth * 0.25f;

			Vector3 size = relativeSize;
			Vector2 offset = pivotOffset;
			Vector4 padding = relativePadding;

			float x0 = offset.x * size.x - padding.x;
			float y0 = offset.y * size.y + padding.y;

			float x1 = x0 + size.x + padding.x + padding.z;
			float y1 = y0 - size.y - padding.y - padding.w;

			pos.x = (x0 + x1) * 0.5f;
			pos.y = (y0 + y1) * 0.5f;

			size.x = (x1 - x0);
			size.y = (y1 - y0);

			// Draw the gizmo
			Gizmos.matrix = cachedTransform.localToWorldMatrix;
			Gizmos.color = (UnityEditor.Selection.activeGameObject == gameObject) ? Color.green : outline;
			Gizmos.DrawWireCube(pos, size);

			// Make the widget selectable
			size.z = 0.01f;
			Gizmos.color = Color.clear;
			Gizmos.DrawCube(pos, size);
		}
	}
#endif

	/// <summary>
	/// Update the widget and fill its geometry if necessary. Returns whether something was changed.
	/// </summary>

	public bool UpdateGeometry (UIPanel p, ref Matrix4x4 worldToPanel, bool parentMoved, bool generateNormals)
	{
		if (material == null) return false;

		if (OnUpdate() || mChanged)
		{
			mChanged = false;

			if (NGUITools.GetActive(mGo))
			{
				mPanel = p;
				mGeom.Clear();
				OnFill(mGeom.verts, mGeom.uvs, mGeom.cols);

				if (mGeom.hasVertices)
				{
					Vector3 offset = pivotOffset;
					Vector2 scale = relativeSize;

					offset.x *= scale.x;
					offset.y *= scale.y;

					mGeom.ApplyOffset(offset);
					mGeom.ApplyTransform(worldToPanel * cachedTransform.localToWorldMatrix, generateNormals);
				}
				return true;
			}
			else if (mGeom.hasVertices)
			{
				mGeom.Clear();
				return true;
			}
			return false;
		}
		else if (mGeom.hasVertices && parentMoved)
		{
			mGeom.ApplyTransform(worldToPanel * cachedTransform.localToWorldMatrix, generateNormals);
		}
		return false;
	}

	/// <summary>
	/// Append the local geometry buffers to the specified ones.
	/// </summary>

	public void WriteToBuffers (BetterList<Vector3> v, BetterList<Vector2> u, BetterList<Color32> c, BetterList<Vector3> n, BetterList<Vector4> t)
	{
		mGeom.WriteToBuffers(v, u, c, n, t);
	}

	/// <summary>
	/// Make the widget pixel-perfect.
	/// </summary>

	virtual public void MakePixelPerfect ()
	{
		Vector3 scale = cachedTransform.localScale;

		int width  = Mathf.RoundToInt(scale.x);
		int height = Mathf.RoundToInt(scale.y);

		scale.x = width;
		scale.y = height;
		scale.z = 1f;

		Vector3 pos = cachedTransform.localPosition;
		pos.z = Mathf.RoundToInt(pos.z);

		if (width % 2 == 1 && (pivot == Pivot.Top || pivot == Pivot.Center || pivot == Pivot.Bottom))
		{
			pos.x = Mathf.Floor(pos.x) + 0.5f;
		}
		else
		{
			pos.x = Mathf.Round(pos.x);
		}

		if (height % 2 == 1 && (pivot == Pivot.Left || pivot == Pivot.Center || pivot == Pivot.Right))
		{
			pos.y = Mathf.Ceil(pos.y) - 0.5f;
		}
		else
		{
			pos.y = Mathf.Round(pos.y);
		}

		cachedTransform.localPosition = pos;
		cachedTransform.localScale = scale;
	}

	/// <summary>
	/// Visible size of the widget in relative coordinates. In most cases this can remain at (1, 1).
	/// If you want to figure out the widget's size in pixels, scale this value by cachedTransform.localScale.
	/// </summary>

	virtual public Vector2 relativeSize { get { return Vector2.one; } }

	/// <summary>
	/// Extra padding around the sprite, in pixels.
	/// </summary>

	virtual public Vector4 relativePadding { get { return Vector4.zero; } }

	/// <summary>
	/// Dimensions of the sprite's border, if any.
	/// </summary>

	virtual public Vector4 border { get { return Vector4.zero; } }

	/// <summary>
	/// Whether the material will be kept when the widget gets disabled (by default no, it won't be).
	/// </summary>

	virtual public bool keepMaterial { get { return false; } }

	/// <summary>
	/// Whether this widget will automatically become pixel-perfect after resize operation finishes.
	/// </summary>

	virtual public bool pixelPerfectAfterResize { get { return false; } }

	/// <summary>
	/// Virtual Start() functionality for widgets.
	/// </summary>

	virtual protected void OnStart () { }

	/// <summary>
	/// Virtual version of the Update function. Should return 'true' if the widget has changed visually.
	/// </summary>

	virtual public bool OnUpdate () { return false; }

	/// <summary>
	/// Virtual function called by the UIPanel that fills the buffers.
	/// </summary>

	virtual public void OnFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols) { }
}
