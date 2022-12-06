using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NPCPooler : MonoBehaviour
{

    [Serializable]
    public struct Pool
    {
        public Queue<GameObject> pooledNpc;
        public GameObject npcPrefabs;
        public int poolSize;
    }

    [SerializeField] private Pool[] pools = null;


    private void Awake()
    {
        QueueUp();
    }

    public void QueueUp()
    {
        for (int i = 0; i < pools.Length; i++) // Kaç adet pool olacak farklý objemiz var onun için yaptýk.
        {
            pools[i].pooledNpc = new Queue<GameObject>();
            for (int j = 0; j < pools[i].poolSize; j++)
            {
                GameObject obj = Instantiate(pools[i].npcPrefabs); // Objeyi size imiz ne kadar sa o kadar klonladýk
                obj.SetActive(false);

                pools[i].pooledNpc.Enqueue(obj);  // Klonlanan objeleri sýraya aldýk.

            }
        }

    }

    public GameObject GetPooledNpc(int objectType)
    {
        if (objectType >= pools.Length)
        {
            return null;
        }

        GameObject obj = pools[objectType].pooledNpc.Dequeue(); // Klonlanan objeyi sýradan çýkardýk.

        obj.SetActive(true); // Sýradan çýkardýgýmýz objeyi oyunda aktif hale getirdik.

        pools[objectType].pooledNpc.Enqueue(obj); //  objeyi tekrar sýraya aldýk.

        return obj;
    }
}
