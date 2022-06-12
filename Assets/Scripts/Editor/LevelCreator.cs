using System;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Collections.Generic;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Collections;
using Unity.EditorCoroutines.Editor;

#if UNITY_EDITOR
[ExecuteInEditMode]
public class LevelCreator : EditorWindow
{
    private readonly List<GameObject> circleReferences = new List<GameObject>();
    private float circleY;
    private GameObject MainCylinder;
    private int levelCount;

    [MenuItem("Tools/Qubits/Level Creator")]
    public static void ShowLevelCreator()
    {
        GetWindow<LevelCreator>("Level Creator");
    }

    private void OnFocus()
    {
        circleReferences.Clear();
        Addressables.LoadAssetsAsync<GameObject>("Circle", circle =>
        {
            circleReferences.Add(circle);
        });

        circleY = 52.0f;
        levelCount = 1;
    }

    private void OnGUI()
    {
        #region Level Creator
        levelCount = Slider("Level Count", levelCount, 100);

        if (GUILayout.Button($"Create {levelCount} Levels"))
        {
            EditorCoroutineUtility.StartCoroutine(CreateScene(), this);
        }

        #endregion

        #region Ping MainCylinder
        if (Selection.activeGameObject != GameObject.FindGameObjectWithTag("MainCylinder"))
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

    private IEnumerator CreateScene()
    {
        for (int i = 0; i < levelCount; i++)
        {
            Scene newScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

            SetRenderSettings();

            AsyncOperationHandle<IList<GameObject>> essentials = Addressables.LoadAssetsAsync<GameObject>("Essentials", o =>
            {
                Utils.SpawnPrefab(o);
            });

            yield return essentials;

            int sceneCount = GetSceneCount();

            if (sceneCount % 10 == 0)
            {
                SpawnTwistyCircles();
            }
            else
            {
                SpawnCircles();
            }

            EditorSceneManager.SaveScene(newScene, $"Assets/Scenes/Level {sceneCount}.unity");
        }
    }

    private int GetSceneCount()
    {
        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo("Assets/Scenes/");
        return dir.GetFiles().Length / 2;
    }

    private void SpawnCircles()
    {
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
        AsyncOperationHandle<GameObject> o = Addressables.LoadAssetAsync<GameObject>("SingleCircle");
        return o.Result;
    }

    private void FillCylinder(Func<GameObject> func)
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject circle = Utils.SpawnPrefab(func.Invoke(), GameObject.FindGameObjectWithTag("MainCylinder"));
            circle.transform.SetPositionAndRotation(new Vector3(0, circleY), Quaternion.Euler(new Vector3(0, UnityEngine.Random.Range(1, 9) * 45)));

            circleY -= 4;
        }

        circleY = 52.0f;

        MakeSceneDirty();
    }

    private void FillCylinderWithSingleCircle(Func<GameObject> func)
    {
        float startRotation = 105.0f;
        for (int i = 0; i < 10; i++)
        {
            GameObject circle = Utils.SpawnPrefab(func.Invoke(), GameObject.FindGameObjectWithTag("MainCylinder"));
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
        return circleReferences[UnityEngine.Random.Range(0, circleReferences.Count)];
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