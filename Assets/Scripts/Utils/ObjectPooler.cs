using UnityEngine;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance { get; private set; }
    private List<GameObject> _pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        _pooledObjects = new List<GameObject>();
        for (var i = 0; i < amountToPool; i++)
        {
            var pooledObject = Instantiate(objectToPool, transform, false);
            pooledObject.SetActive(false);
            _pooledObjects.Add(pooledObject);
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (var pooledObject in _pooledObjects)
        {
            if (!pooledObject.activeInHierarchy)
            {
                return pooledObject;
            }
        }

        return null;
    }
}
