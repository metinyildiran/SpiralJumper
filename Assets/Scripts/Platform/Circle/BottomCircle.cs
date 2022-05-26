using UnityEngine;

public class BottomCircle : CircleBase
{
    protected override void OnTriggerEnter(Collider other)
    {
        GameManager.instance.GameFinished();
    }
}
