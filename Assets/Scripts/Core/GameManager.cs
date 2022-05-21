using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool canFollow = true;
    private bool canRotateCylinder = true;

    private void Awake()
    {
        instance = this;
    }

    public bool GetCanRotateCylinder()
    {
        return canRotateCylinder;
    }

    public void SetCanRotateCylinder(bool value)
    {
        canRotateCylinder = value;
    }

    public bool GetCanFollow()
    {
        return canFollow;
    }

    public void SetCanFollow(bool value)
    {
        canFollow = value;
    }
}
