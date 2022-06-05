#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
public class RenderSettingsWrapperGenerator : EditorWindow, IPreprocessBuildWithReport
{
    public int callbackOrder { get; }


    public void OnPreprocessBuild(BuildReport report)
    {
        RebuildRenderSettingsWrappers();
    }

    [MenuItem("Tools/Narry/Build Rendersettings Caches")]
    private static void RebuildRenderSettingsWrappers()
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {

        }

        UnityEditor.SceneManagement.EditorSceneManager.OpenScene(SceneUtility.GetScenePathByBuildIndex(1));
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));
        var scene = SceneManager.GetActiveScene();
        var rswo = ScriptableObject.CreateInstance<RenderSettingsWrapperObject>();
        rswo.SetWrapperFromRenderSettings();
        EditorUtility.SetDirty(rswo);
        var dest = "Assets/Resources/Settings/Render Settings.asset";

        AssetDatabase.CreateAsset(rswo, dest);
        AssetDatabase.SaveAssets();

        UnityEditor.SceneManagement.EditorSceneManager.OpenScene(SceneUtility.GetScenePathByBuildIndex(0));
        UnityEngine.SceneManagement.SceneManager.SetActiveScene(UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex(0));
    }
}
#endif