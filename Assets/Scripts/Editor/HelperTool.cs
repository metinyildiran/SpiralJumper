using UnityEditor;
using UnityEngine;

public class HelperTool : EditorWindow
{
    [MenuItem("Tools/Qubits/Helper Tool")]
    public static void ShowHelperTool()
    {
        GetWindow<HelperTool>("Helper Tool");
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Open Save File Path"))
        {
            EditorUtility.RevealInFinder(
                $"C:\\Users\\{System.Environment.UserName}\\AppData\\LocalLow\\DefaultCompany\\Spiral Jumper\\");
        }
    }
}
