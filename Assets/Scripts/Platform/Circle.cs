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
        boxCollider.enabled = false;

        Destroy();
    }

    private void Destroy()
    {
        foreach(GameObject o in gameObject.GetChildren())
        {
            Destroy(o);
        }
    }
}
