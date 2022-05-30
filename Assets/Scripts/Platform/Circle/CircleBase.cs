using UnityEngine;

public abstract class CircleBase : MonoBehaviour
{
    protected abstract void OnTriggerEnter(Collider other);
}
