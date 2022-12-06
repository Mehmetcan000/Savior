using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Base : MonoBehaviour
{ 
    [SerializeField] private Transform spawnPoint;

    public void Invoker()
    {
        Invoke("Fire", 0.07f);
    }
    private void Fire()
    {
        if (!GameManager.Instance.gameHasEnded)
        {
            GameObject obj = ObjectPooler.current.GetPooledBullet();
            if (obj == null)
                return;
            obj.transform.position = spawnPoint.position;
            obj.transform.rotation = spawnPoint.rotation;
            obj.SetActive(true);
        }
    }
}
