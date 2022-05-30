using UnityEngine;

public class MiddleCircle : CircleBase
{
    protected override void OnTriggerEnter(Collider other)
    {
        GameManager.instance.OnCirclePassed();
    }
}
