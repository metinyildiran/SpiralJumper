using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class CylinderController : TouchMove
{
    private const float touchMovementSensitivity = 0.35f;

#if UNITY_WEBGL || UNITY_STANDALONE
    private bool isPressed = true;
#endif

    protected override void OnTouchMoved(CallbackContext context)
    {
        if (!GameManager.Instance.GetCanRotateCylinder()) return;

#if UNITY_WEBGL || UNITY_STANDALONE
        WebGLController(context);
#else
        transform.Rotate(Vector3.up, -context.ReadValue<float>() * touchMovementSensitivity);
#endif
    }

#if UNITY_WEBGL || UNITY_STANDALONE
    private void WebGLController(CallbackContext context)
    {
        if (isPressed)
            transform.Rotate(Vector3.up, -context.ReadValue<float>() * touchMovementSensitivity);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isPressed = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isPressed = false;
        }
    }
#endif
}
