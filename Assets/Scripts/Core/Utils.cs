using UnityEngine;

public static class Utils
{
    public static object Print(this object anObject)
    {
        Debug.Log($"{anObject}");

        return anObject;
    }

    public static object Print(this object anObject, string message = "")
    {
        Debug.Log($"{message}: {anObject}");

        return anObject;
    }
}

