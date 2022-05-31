using Core;
using UnityEngine.InputSystem;

public class FailedGameUIPanel : TouchPress
{
    protected override void OnTouchPressed(InputAction.CallbackContext context)
    {
        LevelManager.Instance.RestartLevel();
    }
}
