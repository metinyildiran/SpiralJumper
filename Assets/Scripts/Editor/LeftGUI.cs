#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

#if UNITY_EDITOR
[InitializeOnLoad()]
public static class LeftGUI
{
    static float value = 1;

    static LeftGUI()
    {
        ToolbarExtender.LeftToolbarGUI.Add(DrawLeftGUI);
    }

    static void DrawLeftGUI()
    {
        GUILayout.FlexibleSpace();

        GUILayout.Label("Time Scale");

        value = GUILayout.HorizontalSlider(value, 0.0f, 1.0f, GUILayout.Width(50));

        Time.timeScale = value;
    }
}
#endif
