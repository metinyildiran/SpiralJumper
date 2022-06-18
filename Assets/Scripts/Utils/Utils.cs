using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Utils
{
    public static T Print<T>(this T anObject) where T : notnull
    {
        if (anObject == null)
        {
            Debug.Log("Null");
            return default;
        }

        Debug.Log($"{anObject}");

        return anObject;
    }

    public static T Print<T>(this T anObject, string message) where T : notnull
    {
        if (anObject == null)
        {
            Debug.Log("Null");
            return default;
        }

        Debug.Log($"{message}: {anObject}");

        return anObject;
    }

    public static T PrintScreen<T>(this T anObject) where T : notnull
    {
#if DEBUG
        GUIStyle customStyle = new()
        {
            fontSize = 36,
            alignment = TextAnchor.LowerLeft,
            wordWrap = false
        };

        if (anObject == null)
        {
            GUI.TextArea(new Rect(0, Screen.height - 100, 100, 100), "Null", customStyle);
            return default;
        }

        GUI.TextArea(new Rect(0, Screen.height - 100, 100, 100), anObject.ToString(), customStyle);

        return anObject;
#endif
#pragma warning disable CS0162 // Unreachable code detected
        return anObject;
#pragma warning restore CS0162 // Unreachable code detected
    }

    public static T PrintScreen<T>(this T anObject, string message) where T : notnull
    {
#if DEBUG
        GUIStyle customStyle = new()
        {
            fontSize = 36,
            alignment = TextAnchor.LowerLeft,
            wordWrap = false
        };

        if (anObject == null)
        {
            GUI.TextArea(new Rect(0, Screen.height - 100, 100, 100), "Null", customStyle);
            return default;
        }

        GUI.TextArea(new Rect(0, Screen.height - 100, 100, 100), $"{message}: {anObject}", customStyle);

        return anObject;
#endif
#pragma warning disable CS0162 // Unreachable code detected
        return anObject;
#pragma warning restore CS0162 // Unreachable code detected
    }

    public static List<T> FindInterfaces<T>()
    {
        List<T> interfaces = new List<T>();
        GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (var rootGameObject in rootGameObjects)
        {
            T[] childrenInterfaces = rootGameObject.GetComponentsInChildren<T>(true);
            foreach (var childInterface in childrenInterfaces)
            {
                interfaces.Add(childInterface);
            }
        }
        return interfaces;
    }

    public static RaycastHit[] DrawRay(Vector3 position, Vector3 direction, bool drawDebug = true)
    {
        if (drawDebug)
        {
            Debug.DrawRay(position, direction);
        }

        return Physics.RaycastAll(position, direction);
    }

    public static RaycastHit[] DrawRay(Vector3 position, Vector3 direction, Color color, bool drawDebug = true)
    {
        if (drawDebug)
        {
            Debug.DrawRay(position, direction, color);
        }

        return Physics.RaycastAll(position, direction);
    }

    public static void PlayRandomly(this AudioSource audioSource)
    {
        audioSource.pitch = Random.Range(0.95f, 1.05f);
        audioSource.Play();
    }

    public static void PlayRandomly(this AudioSource audioSource, AudioClip audioClip)
    {
        audioSource.pitch = Random.Range(0.95f, 1.05f);
        audioSource.PlayOneShot(audioClip);
    }

    public static void PlayRandomly(this AudioSource audioSource, float minPitch, float maxPitch)
    {
        audioSource.pitch = Random.Range(minPitch, maxPitch);
        audioSource.Play();
    }

    public static void PlayRandomly(this AudioSource audioSource, AudioClip audioClip, float minPitch, float maxPitch)
    {
        audioSource.pitch = Random.Range(minPitch, maxPitch);
        audioSource.PlayOneShot(audioClip);
    }

    public static GameObject GetChild(this GameObject parent, string childName)
    {
        foreach (Transform child in parent.transform)
        {
            if (child.name == childName)
            {
                return child.gameObject;
            }
        }

        return null;
    }

    public static GameObject GetChildWithTag(this GameObject parent, string tag)
    {
        foreach (Transform child in parent.transform)
        {
            if (child.CompareTag(tag))
            {
                return child.gameObject;
            }
        }

        return null;
    }

#if UNITY_EDITOR
    public static GameObject SpawnPrefab(string path)
    {
        GameObject gameObject = PrefabUtility.InstantiatePrefab(Resources.Load<GameObject>(path)) as GameObject;
        EditorUtility.SetDirty(gameObject);

        return gameObject;
    }

    public static GameObject SpawnPrefab(string path, GameObject parent)
    {

        GameObject gameObject = PrefabUtility.InstantiatePrefab(Resources.Load<GameObject>(path), parent.transform) as GameObject;
        EditorUtility.SetDirty(gameObject);

        return gameObject;
    }

    public static GameObject SpawnPrefab(GameObject o)
    {
        GameObject gameObject = PrefabUtility.InstantiatePrefab(o) as GameObject;
        EditorUtility.SetDirty(gameObject);

        return gameObject;
    }

    public static GameObject SpawnPrefab(GameObject o, GameObject parent)
    {
        GameObject gameObject = PrefabUtility.InstantiatePrefab(o, parent.transform) as GameObject;
        EditorUtility.SetDirty(gameObject);

        return gameObject;
    }
#endif
}
