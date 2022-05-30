using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class CylinderController : TouchMove
{
    private readonly float touchMovementSensitivity = 0.25f;

    protected override void OnTouchMoved(CallbackContext context)
    {
        if (GameManager.instance.GetCanRotateCylinder())
        {
            transform.Rotate(Vector3.up, -context.ReadValue<float>() * touchMovementSensitivity);
        }
    }
}
