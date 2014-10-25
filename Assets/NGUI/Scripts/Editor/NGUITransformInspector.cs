//----------------------------------------------
//			  NGUI: Next-Gen UI kit
// Copyright © 2011-2013 Tasharen Entertainment
// Multi-objects editing support added by 
// Bardelot 'Cripple' Alexandre / Graphicstream.
//----------------------------------------------

using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Transform))]
[CanEditMultipleObjects]
public class NGUITransformInspector : Editor
{
#region Helpers structs/enum
	// Enumeration of axes.
	public enum Axes
	{
		None = 0,
		X = 1,
		Y = 2,
		Z = 4,
		All = X | Y | Z
	}

	/// <summary>
	/// Describes a Vector update. 
	/// We track axes modification using Set#() methods and update a final vector on modified axes only.
	/// We use this because of Multi-editing Objects. We want to update the axes one by one.
	/// </summary>

	public struct VectorWrapper
	{
		public Axes axes;
		public Vector3 value;

		/// <summary>
		/// Force the update of the vector on all Axes using the given value.
		/// </summary>

		public Vector3 ForceSet (Vector3 newValue)
		{
			axes = Axes.All;
			value = newValue;
			return value;
		}

		/// <summary>
		/// Sets the value of the Vector on modified axes.
		/// </summary>

		public Vector3 Set (Vector3 newValue)
		{
			SetX(newValue.x);
			SetY(newValue.y);
			SetZ(newValue.z);
			return value;
		}

		/// <summary>
		/// Sets the value of the X axe.
		/// </summary>

		public Vector3 SetX (float x)
		{
			if (x != value.x)
			{
				value.x = x;
				axes |= Axes.X;
			}
			return value;
		}

		/// <summary>
		/// Sets the value of the Y axe.
		/// </summary>

		public Vector3 SetY (float y)
		{
			if (y != value.y)
			{
				value.y = y;
				axes |= Axes.Y;
			}
			return value;
		}

		/// <summary>
		/// Sets the value of the Z axe.
		/// </summary>

		public Vector3 SetZ (float z)
		{
			if (z != value.z)
			{
				value.z = z;
				axes |= Axes.Z;
			}
			return value;
		}

		/// <summary>
		/// Checks if an axe has been modified.
		/// </summary>

		public bool IsAxeUpdated (Axes axe)
		{
			return (axes & axe) == axe;
		}

		/// <summary>
		/// Validates the current Vector.
		/// </summary>

		public VectorWrapper Validate ()
		{
			Vector3 vector = NGUITransformInspector.Validate(value);
			Set(vector);
			return this;
		}

		/// <summary>
		/// Gets the vector updated on modified axes only.
		/// </summary>

		public Vector3 GetUpdatedVector3 (Vector3 vector)
		{
			if (axes == Axes.All) return value;

			if (IsAxeUpdated(Axes.X)) vector.x = value.x;
			if (IsAxeUpdated(Axes.Y)) vector.y = value.y;
			if (IsAxeUpdated(Axes.Z)) vector.z = value.z;

			return vector;
		}
	}
#endregion

	SerializedProperty mPosition;
	SerializedProperty mRotation;
	SerializedProperty mScale;

	void OnEnable ()
	{
		mPosition = serializedObject.FindProperty("m_LocalPosition");
		mRotation = serializedObject.FindProperty("m_LocalRotation");
		mScale = serializedObject.FindProperty("m_LocalScale");
	}

	/// <summary>
	/// Draw the inspector widget.
	/// </summary>

	public override void OnInspectorGUI ()
	{
		Transform trans = target as Transform;
		EditorGUIUtility.LookLikeControls(15f);

		serializedObject.Update();

		// For clarity purposes, if there is a widget, we want to disable rotation around X and Y, and disable scaling on the Z.
		bool isWidget = false;

		foreach (Object obj in serializedObject.targetObjects)
		{
			Transform t = obj as Transform;

			if (t != null)
			{
				if (t.GetComponent<UIWidget>() != null)
				{
					isWidget = true;
					break;
				}
			}
		}

		// Position
		EditorGUILayout.BeginHorizontal();
		{
			Axes axes = GetMultipleValuesAxes(mPosition);

			if (DrawButton("P", "Reset Position", axes != Axes.None || IsResetPositionValid(trans), 20f))
			{
				NGUIEditorTools.RegisterUndo("Reset Position", serializedObject.targetObjects);

				foreach (Object obj in serializedObject.targetObjects)
				{
					Transform t = obj as Transform;
					if (t != null) t.localPosition = Vector3.zero;
				}
			}

			GUI.changed = false;
			VectorWrapper final = DrawVector3(trans.localPosition, axes, Axes.All);

			if (GUI.changed)
			{
				NGUIEditorTools.RegisterUndo("Reset Position", serializedObject.targetObjects);

				foreach (Object obj in serializedObject.targetObjects)
				{
					Transform t = obj as Transform;

					if (t != null)
					{
						Vector3 v = t.localPosition;
						if ((final.axes & Axes.X) != 0) v.x = final.value.x;
						if ((final.axes & Axes.Y) != 0) v.y = final.value.y;
						if ((final.axes & Axes.Z) != 0) v.z = final.value.z;
						t.localPosition = v;
					}
				}
			}
		}
		EditorGUILayout.EndHorizontal();

		// Rotation
		EditorGUILayout.BeginHorizontal();
		{
			Axes axes = GetMultipleValuesAxes(mRotation);

			if (DrawButton("R", "Reset Rotation", axes != Axes.None || IsResetRotationValid(trans), 20f))
			{
				NGUIEditorTools.RegisterUndo("Reset Rotation", serializedObject.targetObjects);

				foreach (Object obj in serializedObject.targetObjects)
				{
					Transform t = obj as Transform;
					if (t != null) t.localRotation = Quaternion.identity;
				}
			}

			GUI.changed = false;
			VectorWrapper final = DrawVector3(trans.localEulerAngles, axes, isWidget ? Axes.Z : Axes.All);

			if (GUI.changed)
			{
				NGUIEditorTools.RegisterUndo("Reset Rotation", serializedObject.targetObjects);

				foreach (Object obj in serializedObject.targetObjects)
				{
					Transform t = obj as Transform;

					if (t != null)
					{
						Vector3 v = t.localEulerAngles;
						if ((final.axes & Axes.X) != 0) v.x = final.value.x;
						if ((final.axes & Axes.Y) != 0) v.y = final.value.y;
						if ((final.axes & Axes.Z) != 0) v.z = final.value.z;
						t.localEulerAngles = v;
					}
				}
			}
		}
		EditorGUILayout.EndHorizontal();

		// Scale
		EditorGUILayout.BeginHorizontal();
		{
			Axes axes = GetMultipleValuesAxes(mScale);

			if (DrawButton("S", "Reset Scale", (axes != Axes.None || IsResetScaleValid(trans)), 20f))
			{
				NGUIEditorTools.RegisterUndo("Reset Scale", serializedObject.targetObjects);

				foreach (Object obj in serializedObject.targetObjects)
				{
					Transform t = obj as Transform;

					if (t != null)
					{
						UIWidget w = t.GetComponent<UIWidget>();
						if (w != null) w.MakePixelPerfect();
						else t.localScale = Vector3.one;
					}
				}
			}

			GUI.changed = false;
			VectorWrapper final = DrawVector3(trans.localScale, axes, isWidget ? (Axes.X | Axes.Y) : Axes.All);

			if (GUI.changed)
			{
				NGUIEditorTools.RegisterUndo("Reset Scale", serializedObject.targetObjects);

				foreach (Object obj in serializedObject.targetObjects)
				{
					Transform t = obj as Transform;

					if (t != null)
					{
						Vector3 v = t.localScale;
						if ((final.axes & Axes.X) != 0) v.x = final.value.x;
						if ((final.axes & Axes.Y) != 0) v.y = final.value.y;
						if ((final.axes & Axes.Z) != 0) v.z = final.value.z;
						t.localScale = v;
					}
				}
			}
		}
		EditorGUILayout.EndHorizontal();
	}

	/// <summary>
	/// Helper function that draws a button in an enabled or disabled state.
	/// </summary>

	static bool DrawButton (string title, string tooltip, bool enabled, float width)
	{
		if (enabled)
		{
			// Draw a regular button
			return GUILayout.Button(new GUIContent(title, tooltip), GUILayout.Width(width));
		}
		else
		{
			// Button should be disabled -- draw it darkened and ignore its return value
			Color color = GUI.color;
			GUI.color = new Color(1f, 1f, 1f, 0.25f);
			GUILayout.Button(new GUIContent(title, tooltip), GUILayout.Width(width));
			GUI.color = color;
			return false;
		}
	}

	/// <summary>
	/// Helper function that draws a field of 3 floats.
	/// </summary>

	static VectorWrapper DrawVector3 (Vector3 value, Axes shown, Axes editable)
	{
		GUILayoutOption opt = GUILayout.MinWidth(30f);
		VectorWrapper update = new VectorWrapper() { value = value };

		update.SetX(DrawFloatField("X", value.x, ((shown & Axes.X) != Axes.None), ((editable & Axes.X) != Axes.None), opt));
		update.SetY(DrawFloatField("Y", value.y, ((shown & Axes.Y) != Axes.None), ((editable & Axes.Y) != Axes.None), opt));
		update.SetZ(DrawFloatField("Z", value.z, ((shown & Axes.Z) != Axes.None), ((editable & Axes.Z) != Axes.None), opt));

		return update;
	}

	/// <summary>
	/// Draw a float field.
	/// </summary>

	static float DrawFloatField (string name, float value, bool hidden, bool editable, GUILayoutOption opt)
	{
		if (!hidden)
		{
			if (editable)
			{
				return EditorGUILayout.FloatField(name, value, opt);
			}
			else
			{
				GUI.color = new Color(0.7f, 0.7f, 0.7f);
				value = EditorGUILayout.FloatField(name, value, opt);
				GUI.color = Color.white;
				return value;
			}
		}
		float result = value;

		if (editable)
		{
			float.TryParse(EditorGUILayout.TextField(name, "-", opt), out result);
		}
		else
		{
			GUI.color = new Color(0.7f, 0.7f, 0.7f);
			float.TryParse(EditorGUILayout.TextField(name, "-", opt), out result);
			GUI.color = Color.white;
		}
		return result;
	}

	/// <summary>
	/// Helper function that determines whether its worth it to show the reset position button.
	/// </summary>

	static bool IsResetPositionValid (Transform targetTransform)
	{
		Vector3 v = targetTransform.localPosition;
		return (v.x != 0f || v.y != 0f || v.z != 0f);
	}

	/// <summary>
	/// Helper function that determines whether its worth it to show the reset rotation button.
	/// </summary>

	static bool IsResetRotationValid (Transform targetTransform)
	{
		Vector3 v = targetTransform.localEulerAngles;
		return (v.x != 0f || v.y != 0f || v.z != 0f);
	}

	/// <summary>
	/// Helper function that determines whether its worth it to show the reset scale button.
	/// </summary>

	static bool IsResetScaleValid (Transform targetTransform)
	{
		Vector3 v = targetTransform.localScale;
		return (v.x != 1f || v.y != 1f || v.z != 1f);
	}

	/// <summary>
	/// Helper function that removes not-a-number values from the vector.
	/// </summary>

	static Vector3 Validate (Vector3 vector)
	{
		vector.x = float.IsNaN(vector.x) ? 0f : vector.x;
		vector.y = float.IsNaN(vector.y) ? 0f : vector.y;
		vector.z = float.IsNaN(vector.z) ? 0f : vector.z;
		return vector;
	}

	/// <summary>
	/// Gets the axes of a Vector3 which have multiple values.
	/// </summary>

	Axes GetMultipleValuesAxes (SerializedProperty property)
	{
		Axes axes = Axes.None;

		if (!property.hasMultipleDifferentValues)
		{
			return Axes.None;
		}

		// We know that we have at least one serialized object when this is called.
		Vector3 current = GetVector(property, serializedObject.targetObjects[0] as Transform);
		Vector3 next;

		// We check that the value of the axe are all the same.
		foreach (Object obj in serializedObject.targetObjects)
		{
			next = GetVector(property, obj as Transform);

			if (next.x != current.x) axes |= Axes.X;
			if (next.y != current.y) axes |= Axes.Y;
			if (next.z != current.z) axes |= Axes.Z;

			if (axes == Axes.All) return axes;
		}
		return axes;
	}

	/// <summary>
	/// Gets the vector of a transform (scale, position or eulerAngles) corresponding to a given property.
	/// </summary>

	public Vector3 GetVector (SerializedProperty property, Transform trans)
	{
		if (property == mRotation) return trans.localEulerAngles;
		if (property == mPosition) return trans.localPosition;
		if (property == mScale) return trans.localScale;
		return Vector3.zero;
	}
}
