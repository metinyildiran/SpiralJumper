using UnityEngine;

public class BadCirclePiece : CirclePieceBase
{
    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        if (!GameManager.Instance.GetIsSpecialActive())
        {
            GameManager.Instance.SetGameFailed();
        }
    }
}
