//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2013 Tasharen Entertainment
//----------------------------------------------

using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Panel wizard that allows enabling / disabling and selecting panels in the scene.
/// </summary>

public class UIPanelTool : EditorWindow
{
	class Entry
	{
		public UIPanel panel;
		public bool isEnabled = false;
		public bool widgetsEnabled = false;
		public List<UIWidget> widgets = new List<UIWidget>();
	}

	static int Compare (Entry a, Entry b) { return string.Compare(a.panel.name, b.panel.name); }

	Vector2 mScroll = Vector2.zero;

	/// <summary>
	/// Refresh the window on selection.
	/// </summary>

	void OnSelectionChange () { Repaint(); }

	/// <summary>
	/// Collect a list of panels.
	/// </summary>

	static List<UIPanel> GetListOfPanels ()
	{
		List<UIPanel> panels = NGUIEditorTools.FindInScene<UIPanel>();

		for (int i = panels.Count; i > 0; )
		{
			if (!panels[--i].showInPanelTool)
			{
				panels.RemoveAt(i);
			}
		}
		return panels;
	}

	/// <summary>
	/// Get a list of widgets managed by the specified transform's children.
	/// </summary>

	static void GetWidgets (Transform t, List<UIWidget> widgets)
	{
		for (int i = 0; i < t.childCount; ++i)
		{
			Transform child = t.GetChild(i);
			UIWidget w = child.GetComponent<UIWidget>();
			if (w != null) widgets.Add(w);
			else if (child.GetComponent<UIPanel>() == null) GetWidgets(child, widgets);
		}
	}

	/// <summary>
	/// Get a list of widgets managed by the specified panel.
	/// </summary>

	static List<UIWidget> GetWidgets (UIPanel panel)
	{
		List<UIWidget> widgets = new List<UIWidget>();
		if (panel != null) GetWidgets(panel.transform, widgets);
		return widgets;
	}

	/// <summary>
	/// Activate or deactivate the children of the specified transform recursively.
	/// </summary>

	static void SetActiveState (Transform t, bool state)
	{
		for (int i = 0; i < t.childCount; ++i)
		{
			Transform child = t.GetChild(i);
			//if (child.GetComponent<UIPanel>() != null) continue;

			if (state)
			{
				NGUITools.SetActiveSelf(child.gameObject, true);
				SetActiveState(child, true);
			}
			else
			{
				SetActiveState(child, false);
				NGUITools.SetActiveSelf(child.gameObject, false);
			}
			EditorUtility.SetDirty(child.gameObject);
		}
	}

	/// <summary>
	/// Activate or deactivate the specified panel and all of its children.
	/// </summary>

	static void SetActiveState (UIPanel panel, bool state)
	{
		if (state)
		{
			NGUITools.SetActiveSelf(panel.gameObject, true);
			SetActiveState(panel.transform, true);
		}
		else
		{
			SetActiveState(panel.transform, false);
			NGUITools.SetActiveSelf(panel.gameObject, false);
		}
		EditorUtility.SetDirty(panel.gameObject);
	}

	/// <summary>
	/// Draw the custom wizard.
	/// </summary>

	void OnGUI ()
	{
		List<UIPanel> panels = GetListOfPanels();

		if (panels != null && panels.Count > 0)
		{
			UIPanel selectedPanel = NGUITools.FindInParents<UIPanel>(Selection.activeGameObject);

			// First, collect a list of panels with their associated widgets
			List<Entry> entries = new List<Entry>();
			Entry selectedEntry = null;
			bool allEnabled = true;

			foreach (UIPanel panel in panels)
			{
				Entry ent = new Entry();
				ent.panel = panel;
				ent.widgets = GetWidgets(panel);
				ent.isEnabled = panel.enabled && NGUITools.GetActive(panel.gameObject);
				ent.widgetsEnabled = ent.isEnabled;

				if (ent.widgetsEnabled)
				{
					foreach (UIWidget w in ent.widgets)
					{
						if (!NGUITools.GetActive(w.gameObject))
						{
							allEnabled = false;
							ent.widgetsEnabled = false;
							break;
						}
					}
				}
				else allEnabled = false;
				entries.Add(ent);
			}

			// Sort the list alphabetically
			entries.Sort(Compare);

			EditorGUIUtility.LookLikeControls(80f);
			bool showAll = DrawRow(null, null, allEnabled);
			NGUIEditorTools.DrawSeparator();

			mScroll = GUILayout.BeginScrollView(mScroll);

			foreach (Entry ent in entries)
			{
				if (DrawRow(ent, selectedPanel, ent.widgetsEnabled))
				{
					selectedEntry = ent;
				}
			}
			GUILayout.EndScrollView();

			if (showAll)
			{
				foreach (Entry ent in entries)
				{
					SetActiveState(ent.panel, !allEnabled);
				}
			}
			else if (selectedEntry != null)
			{
				SetActiveState(selectedEntry.panel, !selectedEntry.widgetsEnabled);
			}
		}
		else
		{
			GUILayout.Label("No UI Panels found in the scene");
		}
	}

	/// <summary>
	/// Helper function used to print things in columns.
	/// </summary>

	bool DrawRow (Entry ent, UIPanel selected, bool isChecked)
	{
		bool retVal = false;
		string panelName, layer, widgetCount, drawCalls, clipping;

		if (ent != null)
		{
			panelName = ent.panel.name;
			layer = LayerMask.LayerToName(ent.panel.gameObject.layer);
			widgetCount = ent.widgets.Count.ToString();
			drawCalls = ent.panel.drawCalls.size.ToString();
			clipping = (ent.panel.clipping != UIDrawCall.Clipping.None) ? "Yes" : "";
		}
		else
		{
			panelName = "Panel's Name";
			layer = "Layer";
			widgetCount = "WG";
			drawCalls = "DC";
			clipping = "Clip";
		}

		if (ent != null) NGUIEditorTools.HighlightLine(ent.isEnabled ? new Color(0.6f, 0.6f, 0.6f) : Color.black);

		GUILayout.BeginHorizontal();
		{
			GUI.color = Color.white;

			if (isChecked != EditorGUILayout.Toggle(isChecked, GUILayout.Width(20f))) retVal = true;

			if (ent == null)
			{
				GUI.contentColor = Color.white;
			}
			else if (ent.isEnabled)
			{
				GUI.contentColor = (ent.panel == selected) ? new Color(0f, 0.8f, 1f) : Color.white; 
			}
			else
			{
				GUI.contentColor = (ent.panel == selected) ? new Color(0f, 0.5f, 0.8f) : Color.grey;
			}

#if UNITY_3_4
			if (GUILayout.Button(panelName, EditorStyles.structHeadingLabel, GUILayout.MinWidth(100f)))
#else
			if (GUILayout.Button(panelName, EditorStyles.label, GUILayout.MinWidth(100f)))
#endif
			{
				if (ent != null)
				{
					Selection.activeGameObject = ent.panel.gameObject;
					EditorUtility.SetDirty(ent.panel.gameObject);
				}
			}

			GUILayout.Label(layer, GUILayout.Width(ent == null ? 65f : 70f));
			GUILayout.Label(widgetCount, GUILayout.Width(30f));
			GUILayout.Label(drawCalls, GUILayout.Width(30f));
			GUILayout.Label(clipping, GUILayout.Width(30f));

			if (ent == null)
			{
				GUILayout.Label("Giz", GUILayout.Width(24f));
			}
			else
			{
				GUI.contentColor = ent.isEnabled ? Color.white : new Color(0.7f, 0.7f, 0.7f);
				bool debug = (ent.panel.debugInfo == UIPanel.DebugInfo.Gizmos);

				if (debug != EditorGUILayout.Toggle(debug, GUILayout.Width(20f)))
				{
					// debug != value, so it's currently inverse
					ent.panel.debugInfo = debug ? UIPanel.DebugInfo.None : UIPanel.DebugInfo.Gizmos;
					EditorUtility.SetDirty(ent.panel.gameObject);
				}
			}
		}
		GUILayout.EndHorizontal();
		return retVal;
	}
}