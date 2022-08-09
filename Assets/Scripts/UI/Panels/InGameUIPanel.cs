using UnityEngine;
using UnityEngine.InputSystem;

public class InGameUIPanel : TouchMove
{
#if UNITY_WEBGL || UNITY_STANDALONE
    private bool isPressed;
#endif

    protected override void OnTouchMoved(InputAction.CallbackContext context)
    {
        if (!GameManager.Instance.GetCanRotateCylinder()) return;

#if UNITY_WEBGL || UNITY_STANDALONE
        WebGLController();
#else
        gameObject.SetActive(false);
#endif
    }

#if UNITY_WEBGL || UNITY_STANDALONE
    private void WebGLController()
    {
        if (isPressed)
            gameObject.SetActive(false);
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
