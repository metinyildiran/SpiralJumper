using System.Collections;
using UnityEngine;

public class Splash : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2.0f);

        Destroy(gameObject);
    }
}
