using UnityEngine;

public class Circle : MonoBehaviour
{
    private BoxCollider boxCollider;
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.Print();
        boxCollider.enabled = false;

        Invoke(nameof(Destroy), 0.5f);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
