using UnityEngine;

public abstract class CircleBase : MonoBehaviour
{

    private void OnDestroy()
    {
        GameManager.instance.AddScore();
    }
    protected abstract void OnTriggerEnter(Collider other);
}
