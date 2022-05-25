using UnityEngine;

public class Circle : MonoBehaviour
{
    private BoxCollider boxCollider;
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerExit(Collider other)
    {
        boxCollider.enabled = false;

        Invoke(nameof(Destroy), 0.0f);
    }

    private void Destroy()
    {
        foreach(Transform o in transform)
        {
            o.gameObject.SetActive(false);
        }
    }
}
