using UnityEngine;

public class EndlessCylinder : MonoBehaviour
{
    private bool isPassed;

    private EndlessCylinderSpawner endlessCylinderSpawner;
    private BoxCollider boxCollider;

    private void Awake()
    {
        endlessCylinderSpawner = FindObjectOfType<EndlessCylinderSpawner>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(endlessCylinderSpawner.SpawnSingleCylinderRoutine());

        isPassed = true;

        boxCollider.enabled = false;
    }

    private void OnBecameInvisible()
    {
        if (isPassed)
        {
            Destroy(gameObject);
        }
    }
}
