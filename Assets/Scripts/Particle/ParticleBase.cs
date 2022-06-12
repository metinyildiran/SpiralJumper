using System.Collections;
using UnityEngine;

public abstract class ParticleBase : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Destroy());
    }

    protected abstract IEnumerator Destroy();
}
