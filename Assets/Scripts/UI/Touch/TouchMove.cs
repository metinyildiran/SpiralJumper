using static UnityEngine.InputSystem.InputAction;

public abstract class TouchMove : TouchBase
{
    private void Start()
    {
        if (touchControls != null)
            touchControls.MainCylinder.Rotate.started += context => OnTouchMoved(context);
    }

    protected abstract void OnTouchMoved(CallbackContext context);
}
