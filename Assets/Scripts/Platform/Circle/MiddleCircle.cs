using UnityEngine;

public class MiddleCircle : CircleBase
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (!GameManager.Instance.GetIsGameFailed())
        {
            GameManager.Instance.OnCirclePassed();
        }
    }
}
