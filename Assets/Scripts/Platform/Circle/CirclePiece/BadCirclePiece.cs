using UnityEngine;

public class BadCirclePiece : CirclePieceBase
{
    protected override void OnCollisionEnter(Collision collision)
    {
        if (!GameManager.Instance.GetIsSpecialActive())
        {
            GameManager.Instance.GameFailed();
        }
    }
}
