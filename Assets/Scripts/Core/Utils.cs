using UnityEngine;

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

    public static T Print<T>(this T anObject, string message = "") where T : notnull
    {
        if (anObject == null)
        {
            Debug.Log("Null");
            return default;
        }

        Debug.Log($"{message}: {anObject}");

        return anObject;
    }

    public static GameObject[] GetChildren(this GameObject parent)
    {
        GameObject[] children = null;
        Transform[] trs = parent.GetComponentsInChildren<Transform>(true);

        int count = 0;
        foreach (Transform child in trs)
        {
            children[count] = child.gameObject;

            count++;
        }

        return children;
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
}
