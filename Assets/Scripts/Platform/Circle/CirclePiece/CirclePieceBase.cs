using UnityEngine;

public class CirclePieceBase : MonoBehaviour
{
    public void DestroyParent()
    {
        GameManager.Instance.AddScore(20);

        Destroy(transform.parent.gameObject);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {

    }
}
