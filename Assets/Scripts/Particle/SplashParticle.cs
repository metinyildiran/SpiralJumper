using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SplashParticle : ParticleBase
{
    protected override IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.75f);

        Addressables.ReleaseInstance(gameObject);
    }
}
