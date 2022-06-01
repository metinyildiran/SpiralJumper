using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class CylinderController : TouchMove
{
    private const float touchMovementSensitivity = 0.35f;

    protected override void OnTouchMoved(CallbackContext context)
    {
        if (GameManager.Instance.GetCanRotateCylinder())
        {
            transform.Rotate(Vector3.up, -context.ReadValue<float>() * touchMovementSensitivity);
        }
    }
}
