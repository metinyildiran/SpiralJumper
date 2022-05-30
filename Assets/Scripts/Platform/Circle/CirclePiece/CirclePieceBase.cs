using UnityEngine;

public abstract class CirclePieceBase : MonoBehaviour
{
    public void DestroyParent()
    {
        GameManager.instance.AddScore(20);
        Destroy(transform.parent.gameObject);
    }

    protected abstract void OnCollisionEnter(Collision collision);
}
