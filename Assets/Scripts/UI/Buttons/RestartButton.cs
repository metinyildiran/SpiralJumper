using Core;

public class RestartButton : ButtonBase
{
    protected override void OnPressed()
    {
        LevelManager.Instance.RestartLevel();
    }
}
