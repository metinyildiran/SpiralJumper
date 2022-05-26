using Core;

public class FinishedLevelUIPanel : UIPanelBase
{
    protected override void OnPressed()
    {
        LevelManager.Instance.LoadNextLevel();
    }
}

