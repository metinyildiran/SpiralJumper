using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class EndlessCylinderSpawner : MonoBehaviour
{
    private readonly List<GameObject> circleReferences = new List<GameObject>();
    public GameObject endlessCylinder;
    private float circleY;
    private const float cylinderOffset = -44f;
    public float cylinderCount = 1;

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

        circleY = 56.0f;

        yield return new WaitWhile(() => endlessCylinder == null);
    }

    public IEnumerator SpawnSingleCylinderRoutine()
    {
        yield return new WaitWhile(() => endlessCylinder == null);

        GameObject cylinder = Instantiate(endlessCylinder);

        for (int j = 0; j < 11; j++)
        {
            Instantiate(GetRandomCircle(), new Vector3(0, circleY), Quaternion.Euler(new Vector3(0, UnityEngine.Random.Range(1, 9) * 45)),
                cylinder.transform);

            circleY -= 4;
        }

        circleY = 56.0f;

        cylinder.transform.position = new Vector3(0, cylinderOffset * cylinderCount);

        cylinderCount++;
    }

    public void ResetEndlessMode()
    {
        foreach (GameObject endlessCylinder in GameObject.FindGameObjectsWithTag("EndlessCylinder"))
        {
            Destroy(endlessCylinder);
        }

        cylinderCount = 1;
    }

    private GameObject GetRandomCircle()
    {
        return circleReferences[Random.Range(0, circleReferences.Count)];
    }
}
