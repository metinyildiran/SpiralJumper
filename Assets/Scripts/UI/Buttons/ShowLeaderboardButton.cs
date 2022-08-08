public class ShowLeaderboardButton : ButtonBase
{
    protected override void OnPressed()
    {
        FindObjectOfType<UIManager>().ShowLeaderboard();

        GameManager.Instance.SetCanRotateCylinder(false);
    }
}
