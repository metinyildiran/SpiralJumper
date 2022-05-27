using UnityEngine;

public class CylinderController : TouchMove
{
    private readonly float keyboardMovementSensitivity = 3f;
    private readonly float touchMovementSensitivity = 0.25f;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

#if UNITY_EDITOR
        if (GameManager.instance.GetCanRotateCylinder())
        {
            KeyboardControl();
        }
#endif
    }

    private void KeyboardControl()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up, -horizontalInput * keyboardMovementSensitivity);
    }

    protected override void OnTouchMoved(Touch touch)
    {
        if (GameManager.instance.GetCanRotateCylinder())
        {
            transform.Rotate(Vector3.up, -touch.deltaPosition.x * touchMovementSensitivity);
        }
    }
}
