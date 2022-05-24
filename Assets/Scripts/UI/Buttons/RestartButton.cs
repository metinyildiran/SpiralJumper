using Core;

namespace Buttons
{
    public class RestartButton : ButtonBase
    {
        protected override void OnPressed()
        {
            LevelManager.Instance.RestartLevel();
        }
    }
}