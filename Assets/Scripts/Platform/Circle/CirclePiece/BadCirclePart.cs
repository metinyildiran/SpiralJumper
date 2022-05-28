using UnityEngine;

public class BadCirclePart : CirclePieceBase
{
    protected override void OnCollisionEnter(Collision collision)
    {
        GameManager.instance.GameFailed();
    }
}
