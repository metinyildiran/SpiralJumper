using UnityEngine.InputSystem;

public class InGameUIPanel : TouchMove
{
    protected override void OnTouchMoved(InputAction.CallbackContext context)
    {
        gameObject.SetActive(false);
    }
}
