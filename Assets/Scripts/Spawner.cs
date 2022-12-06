using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Objeleri 4 ayr� noktadaki spawn pointlerden spawnlatmam laz�m.
    // 3 saniye aral�kla rastgele olarak belli noktalardan spawnlan�p player objesinin �zerine gelecek.

    public Transform[] spawnPoint; 

    [SerializeField] private float spawnInterval;

    [SerializeField] private NPCPooler pooler = null;

    private void Awake()
    {
        ScoreManager.onEnemyKillCount +=SpawnAcceleration;
        ScoreManager.onEnemySlowDown += SpawnSlowDown;
    }
    void Start()
    {
        StartCoroutine(nameof(SpawnRoutine));
    }

    public void SpawnAcceleration()
    {
        spawnInterval = 1.3f;
        Debug.Log(spawnInterval);
    }

    public void SpawnSlowDown()
    {
        spawnInterval = 2f;  
    }

    private IEnumerator SpawnRoutine()
    {
            while (!GameManager.Instance.gameHasEnded)
            {
                GameObject obj = pooler.GetPooledNpc(Random.Range(0, 2));
                obj.transform.position = spawnPoint[Random.Range(0, 4)].position;
                obj.GetComponent<IMove>().Move();

                yield return new WaitForSeconds(spawnInterval);
            } 
    }

}
