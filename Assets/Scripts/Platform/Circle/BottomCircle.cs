public class BottomCircle : CircleBase
{
    protected override void OnTriggerEnter()
    {
        GameManager.Instance.GameFinished();
    }
}
