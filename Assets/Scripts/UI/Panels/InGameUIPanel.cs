using UnityEngine.InputSystem;

public class InGameUIPanel : TouchMove
{
    protected override void OnTouchMoved(InputAction.CallbackContext context)
    {
        if (!GameManager.Instance.GetCanRotateCylinder()) return;

        gameObject.SetActive(false);
    }
}
