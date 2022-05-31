using UnityEngine;

public class BottomCircle : CircleBase
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (!GameManager.Instance.GetIsGameFailed())
        {
            GameManager.Instance.GameFinished();
        }
    }
}
