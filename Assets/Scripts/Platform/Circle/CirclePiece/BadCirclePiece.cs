using UnityEngine;

public class BadCirclePiece : CirclePieceBase
{
    protected override void OnCollisionEnter(Collision collision)
    {
        if (!GameManager.instance.GetIsSpecialActive())
        {
            GameManager.instance.GameFailed();
        }
    }
}
