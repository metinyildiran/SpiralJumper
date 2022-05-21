using Core;

namespace Buttons
{
    public class NextLevelButton : ButtonBase
    {
        protected override void OnPressed()
        {
            LevelManager.Instance.LoadNextLevel();
        }
    }
}