using static UnityEngine.InputSystem.InputAction;

public abstract class TouchPress : TouchBase
{
    private void Start()
    {
        if (touchControls != null)
            touchControls.UI.Press.performed += context => OnTouchPressed(context);
    }

    protected abstract void OnTouchPressed(CallbackContext context);
}
