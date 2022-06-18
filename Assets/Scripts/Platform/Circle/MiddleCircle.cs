public class MiddleCircle : CircleBase
{
    protected override void OnTriggerEnter()
    {
        GameManager.Instance.OnCirclePassed();
        AudioManager.Instance.PlayPassSound();
    }
}
