using UnityEngine;

public abstract class CircleBase : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (!GameManager.Instance.GetIsGameFailed())
        {
            OnTriggerEnter();
        }
    }

    protected abstract void OnTriggerEnter();
}
