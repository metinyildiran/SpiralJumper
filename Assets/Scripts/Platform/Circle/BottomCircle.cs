using UnityEngine;

public class BottomCircle : CircleBase
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (!GameManager.instance.GetIsGameFailed())
        {
            GameManager.instance.GameFinished();
        }
    }
}
