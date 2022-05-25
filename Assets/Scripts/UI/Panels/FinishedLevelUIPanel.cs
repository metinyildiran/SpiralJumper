using Core;

public class FinishedLevelUIPanel : UIPanelBase
{
    protected override void OnPressed()
    {
        print("sdfdsfdsfds");
        LevelManager.Instance.LoadNextLevel();
    }
}

