using Core;

public class FailedGameUIPanel : UIPanelBase
{
    protected override void OnPressed()
    {
        LevelManager.Instance.RestartLevel();
    }
}
