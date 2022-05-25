using Core;

public class EndGameUIPanel : UIPanelBase
{
    protected override void OnPressed()
    {
        LevelManager.Instance.RestartLevel();
    }
}
