using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class EndlessCylinder : MonoBehaviour
{
    private readonly List<GameObject> circleReferences = new List<GameObject>();
    public GameObject endlessCylinder;
    private float circleY;
    private float cylinderCount = 1;

    private IEnumerator Start()
    {
        yield return Addressables.LoadAssetsAsync<GameObject>("Circle", circle =>
        {
            circleReferences.Add(circle);
        });

        Addressables.LoadAssetAsync<GameObject>("EndlessCylinder").Completed += (handle) =>
        {
            endlessCylinder = handle.Result;
        };

        yield return new WaitWhile(() => endlessCylinder == null);

        circleY = 56.0f;

        FillEndlessCylinder(GetRandomCircle);
    }

    private void FillEndlessCylinder(Func<GameObject> func)
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject cylinder = SpawnEndlessCylinder();
            cylinder.transform.position = new Vector3(0, -56 * cylinderCount);

            for (int j = 0; j < 12; j++)
            {
                Instantiate(func.Invoke(), new Vector3(0, circleY), Quaternion.Euler(new Vector3(0, UnityEngine.Random.Range(1, 9) * 45)),
                    cylinder.transform);

                circleY -= 4;
            }

            cylinderCount++;
        }

        circleY = 56.0f;
    }

    private GameObject SpawnEndlessCylinder()
    {
        return Instantiate(endlessCylinder);
    }

    private GameObject GetRandomCircle()
    {
        return circleReferences[UnityEngine.Random.Range(0, circleReferences.Count)];
    }
}
