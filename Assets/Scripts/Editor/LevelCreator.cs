#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
public class LevelCreator : EditorWindow
{
    private RenderSettingsWrapperObject _renderSettings;

    [SerializeField] private GameObject[] circleReferences;
    private float circleY;
    GameObject MainCylinder;
    private int levelCount;

    [MenuItem("Tools/Qubits/Level Creator")]
    public static void ShowLevelCreator()
    {
        GetWindow<LevelCreator>("Level Creator");
    }

    private void OnValidate()
    {
        circleReferences = Resources.LoadAll<GameObject>("Prefabs/Circles/UsableCircles");
        _renderSettings = Resources.Load<RenderSettingsWrapperObject>("Render Settings");

        circleY = 52.0f;
        levelCount = 1;
    }

    private void OnGUI()
    {
        #region Level Creator
        levelCount = Slider("Level Count", levelCount, 100);

        if (GUILayout.Button($"Create {levelCount} Levels"))
        {
            CreateScene(levelCount);
        }

        #endregion

        #region Ping MainCylinder
        if (Selection.activeGameObject == null)
        {
            CenteredLabel("Select the MainCylinder to work with it");

            //EditorGUIUtility.PingObject(GameObject.FindGameObjectWithTag("MainCylinder"));

            return;
        }

        MainCylinder = Selection.activeGameObject.CompareTag("MainCylinder") ? Selection.activeGameObject : null;

        if (MainCylinder == null)
        {
            CenteredLabel("Select the MainCylinder to work with it");

            //EditorGUIUtility.PingObject(GameObject.FindGameObjectWithTag("MainCylinder"));

            return;
        }
        #endregion

        #region MainCylinder

        GUILayout.Space(10);

        CenteredLabel("Main Cylinder");

        if (GUILayout.Button("Fill"))
        {
            SpawnCircles();
        }

        if (GUILayout.Button("Clear"))
        {
            ClearMainCylinder();
        }
        #endregion
    }

    private void CreateScene(int count = 1)
    {
        for (int i = 0; i < count; i++)
        {
            Scene newScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

            SetRenderSettings();

            foreach (GameObject o in Resources.LoadAll<GameObject>("Prefabs/Essentials"))
            {
                Utils.SpawnPrefab(o);
            }

            Selection.activeGameObject = GameObject.FindGameObjectWithTag("MainCylinder");

            SpawnCircles();

            EditorSceneManager.SaveScene(newScene, $"Assets/Resources/Scenes/Level {(GetSceneCount() / 2)}.unity");
        }
    }

    private int GetSceneCount()
    {
        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo("Assets/Resources/Scenes/");
        return dir.GetFiles().Length;
    }

    private void SpawnCylinder(GameObject MainCylinder)
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject circle = Utils.SpawnPrefab(GetRandomCircle(), MainCylinder);
            circle.transform.SetPositionAndRotation(new Vector3(0, circleY), Quaternion.Euler(new Vector3(0, Random.Range(1, 9) * 45)));

            circleY -= 4;
        }

        circleY = 52.0f;

        MakeSceneDirty();
    }

    private void SpawnCircles()
    {
        MainCylinder = GameObject.FindGameObjectWithTag("MainCylinder");

        if (GameObject.FindGameObjectWithTag("Circle"))
        {
            ClearMainCylinder();
            SpawnCylinder(MainCylinder);
            return;
        }

        SpawnCylinder(MainCylinder);
    }

    private void SetRenderSettings()
    {
        RenderSettings.reflectionIntensity = 1;
        RenderSettings.skybox = null;
        RenderSettings.ambientLight = _renderSettings.ambientLight;
    }

    private void ClearMainCylinder()
    {
        foreach (GameObject child in GameObject.FindGameObjectsWithTag("Circle"))
        {
            DestroyImmediate(child);
        }

        circleY = 52.0f;

        MakeSceneDirty();
    }

    private void MakeSceneDirty()
    {
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }

    private GameObject GetRandomCircle()
    {
        return circleReferences[Random.Range(0, circleReferences.Length)];
    }

    private int Slider(string label, int scale, int maxValue = 20)
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label(label);
        scale = (int)EditorGUILayout.Slider(scale, 1, maxValue);
        GUILayout.EndHorizontal(); return scale;
    }

    private void CenteredLabel(string text)
    {
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label(text, EditorStyles.boldLabel);
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
    }
}
#endif