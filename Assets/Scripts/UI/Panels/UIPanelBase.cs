public abstract class UIPanelBase : TouchPress
{
    protected override void OnTouchPressed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        OnPressed();
    }

    protected abstract void OnPressed();
}
