using UnityEngine;

public class CylinderController : TouchMove
{
    private readonly float keyboardMovementSensitivity = 3f;
    private readonly float touchMovementSensitivity = 0.25f;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (GameManager.instance.CanPlayGame())
        {
            KeyboardControl();
        }
    }

    private void KeyboardControl()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up, -horizontalInput * keyboardMovementSensitivity);
    }

    protected override void OnTouchMoved(Touch touch)
    {
        if (GameManager.instance.CanPlayGame())
        {
            transform.Rotate(Vector3.up, -touch.deltaPosition.x * touchMovementSensitivity);
        }
    }
}
