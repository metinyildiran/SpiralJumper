using UnityEngine;

public class CylinderController : MonoBehaviour
{
    private Touch _touch;
    private readonly float keyboardMovementSensitivity = 3f;
    private readonly float touchMovementSensitivity = 0.25f;

    void FixedUpdate()
    {
        KeyboardControl();
        TouchControl();
    }

    private void KeyboardControl()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up, -horizontalInput * keyboardMovementSensitivity);
    }

    private void TouchControl()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Moved)
            {
                transform.Rotate(Vector3.up, -_touch.deltaPosition.x * touchMovementSensitivity);
            }
        }
    }
}
