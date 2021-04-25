using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    private List<BlockView> pooledObjects;

    [SerializeField]
    private BlockView objectToPool;

    [SerializeField]
    private int amountToPool;

    [SerializeField]
    private Transform parent;

    private void Awake() {
        SharedInstance = this;
    }

    private void Start() {

        pooledObjects = new List<BlockView>();
        BlockView tmp;

        for (int i = 0; i < amountToPool; i++) {

            tmp = Instantiate(objectToPool, parent);
            tmp.prefab.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public BlockView GetPooledObject() {

        for (int i = 0; i < amountToPool; i++) {
            if(!pooledObjects[i].prefab.activeInHierarchy) {

                return pooledObjects[i];
            }
        }

        return null;
    }
}
