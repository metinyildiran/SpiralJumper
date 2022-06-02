using Core;

public class QuitButton : ButtonBase
{
    protected override void OnPressed()
    {
        LevelManager.Instance.QuitGame();
    }
}
