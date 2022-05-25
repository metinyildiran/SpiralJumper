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

    public static void PlayRandomly(this AudioSource audioSource, float minPitch, float maxPitch)
    {
        audioSource.pitch = Random.Range(minPitch, maxPitch);
        audioSource.Play();
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
