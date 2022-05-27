using UnityEngine;

public abstract class TouchBase : MonoBehaviour
{
    protected TouchControls touchControls;

    protected virtual void Awake()
    {
        touchControls = new TouchControls();
    }

    private void OnEnable()
    {
        if (touchControls != null)
            touchControls.Enable();
    }

    private void OnDisable()
    {
        if (touchControls != null)
            touchControls.Disable();
    }
}
