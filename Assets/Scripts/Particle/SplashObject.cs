using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SplashObject : ParticleBase
{
    protected override IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2.0f);

        Addressables.ReleaseInstance(gameObject);
    }
}
