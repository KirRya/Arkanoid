using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPool : MonoBehaviour
{
    public static HealthPool SharedInstance;
    private List<GameObject> pooledObjects;

    [SerializeField]
    private GameObject objectToPool;

    [SerializeField]
    private int amountToPool;

    [SerializeField]
    private Transform parent;

    private void Awake() {
        SharedInstance = this;
    }

    private void Start() {

        pooledObjects = new List<GameObject>();
        GameObject tmp;

        for (int i = 0; i < amountToPool; i++) {

            tmp = Instantiate(objectToPool, parent);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++) {
            if (!pooledObjects[i].activeInHierarchy) {

                return pooledObjects[i];
            }
        }

        return null;
    }
}
