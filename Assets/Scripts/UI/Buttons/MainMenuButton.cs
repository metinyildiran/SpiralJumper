using Core;

namespace Buttons
{
    public class MainMenuButton : ButtonBase
    {
        protected override void OnPressed()
        {
            LevelManager.Instance.GoToMainMenu();
        }
    }
}