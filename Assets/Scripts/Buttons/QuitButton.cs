using Core;

namespace Buttons
{
    public class QuitButton : ButtonBase
    {
        protected override void OnPressed()
        {
            LevelManager.Instance.QuitGame();
        }
    }
}