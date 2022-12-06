using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler current;
    public GameObject pooledObject;
    public int pooledAmount;
    public bool willGrow;

    private List<GameObject> pooledObjectsBullet;
    
    void Start()
    {
        pooledObjectsBullet = new List<GameObject>();
        
        current = this;
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjectsBullet.Add(obj);  
        }
    }

    public GameObject GetPooledBullet()
    {
        for (int i = 0; i < pooledObjectsBullet.Count; i++)
        {
            if (!pooledObjectsBullet[i].activeInHierarchy)
            {
                return pooledObjectsBullet[i];
            }
        }
        if (willGrow)
        {
            GameObject obj = Instantiate(pooledObject);
            pooledObjectsBullet.Add(obj);
            return obj;
        }
        return null;
    }

    
}
