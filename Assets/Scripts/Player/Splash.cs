using System.Collections;
using UnityEngine;

public class Splash : MonoBehaviour
{
    private GameObject splashPooler;

    private void Awake()
    {
        splashPooler = transform.parent.gameObject;
    }

    private void OnEnable()
    {
        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(60.0f);

        gameObject.transform.position = Vector3.zero;
        gameObject.transform.parent = splashPooler.transform;
        gameObject.SetActive(false);
    }
}
