using UnityEngine.InputSystem;

public class FinishedLevelUIPanel : TouchPress
{
    protected override void OnTouchPressed(InputAction.CallbackContext context)
    {
        LevelManager.Instance.LoadNextLevel();
    }
}
