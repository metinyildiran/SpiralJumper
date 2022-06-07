#if UNITY_EDITOR
using System;
using UnityEditor;
#endif
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
public class LevelCreator : EditorWindow
{
    private RenderSettingsWrapperObject _renderSettings;

    private GameObject[] circleReferences;
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
        levelCount = Slider("Level Count", levelCount, 1000);

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

            int sceneCount = GetSceneCount();

            if (sceneCount % 10 == 0)
            {
                SpawnTwistyCircles();
            }
            else
            {
                SpawnCircles();
            }

            EditorSceneManager.SaveScene(newScene, $"Assets/Resources/Scenes/Level {sceneCount}.unity");
        }
    }

    private int GetSceneCount()
    {
        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo("Assets/Resources/Scenes/");
        return dir.GetFiles().Length / 2;
    }

    private void SpawnCircles()
    {
        MainCylinder = GameObject.FindGameObjectWithTag("MainCylinder");

        if (GameObject.FindGameObjectWithTag("Circle"))
        {
            ClearMainCylinder();
            FillCylinder(GetRandomCircle);
            return;
        }

        FillCylinder(GetRandomCircle);
    }

    private void SpawnTwistyCircles()
    {
        MainCylinder = GameObject.FindGameObjectWithTag("MainCylinder");

        if (GameObject.FindGameObjectWithTag("Circle"))
        {
            ClearMainCylinder();
            FillCylinderWithSingleCircle(GetSingleCicle);
            return;
        }

        FillCylinderWithSingleCircle(GetSingleCicle);
    }

    private GameObject GetSingleCicle()
    {
        return Resources.Load<GameObject>("Prefabs/Circles/SingleCircle");
    }

    private void FillCylinder(Func<GameObject> func)
    {
        MainCylinder = GameObject.FindGameObjectWithTag("MainCylinder");

        for (int i = 0; i < 10; i++)
        {
            GameObject circle = Utils.SpawnPrefab(func.Invoke(), MainCylinder);
            circle.transform.SetPositionAndRotation(new Vector3(0, circleY), Quaternion.Euler(new Vector3(0, UnityEngine.Random.Range(1, 9) * 45)));

            circleY -= 4;
        }

        circleY = 52.0f;

        MakeSceneDirty();
    }

    private void FillCylinderWithSingleCircle(Func<GameObject> func)
    {
        MainCylinder = GameObject.FindGameObjectWithTag("MainCylinder");

        float startRotation = 105.0f;
        for (int i = 0; i < 10; i++)
        {
            GameObject circle = Utils.SpawnPrefab(func.Invoke(), MainCylinder);
            circle.transform.SetPositionAndRotation(new Vector3(0, circleY), Quaternion.Euler(new Vector3(0, startRotation)));

            startRotation += 15;

            circleY -= 4;
        }

        circleY = 52.0f;

        MakeSceneDirty();
    }

    private void SetRenderSettings()
    {
        RenderSettings.reflectionIntensity = 1;
        RenderSettings.skybox = Resources.Load<Material>("Materials/M_GradientSkyBackground");
        RenderSettings.ambientIntensity = 0.3f;
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
        return circleReferences[UnityEngine.Random.Range(0, circleReferences.Length)];
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