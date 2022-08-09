using UnityEngine;

public class EndlessCylinder : MonoBehaviour
{
    private bool isPassed;

    private EndlessCylinderSpawner endlessCylinderSpawner;
    private ColorManager colorManager;
    private BoxCollider boxCollider;

    private void Awake()
    {
        endlessCylinderSpawner = FindObjectOfType<EndlessCylinderSpawner>();
        colorManager = FindObjectOfType<ColorManager>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(endlessCylinderSpawner.SpawnSingleCylinderRoutine());

#if UNITY_EDITOR
        colorManager.SwitchEndlessModeColors();
#endif

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
