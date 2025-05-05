using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public Transform[] spawnPoints;

    public GameObject waveSpawner;
    private float spawnChance = 0.05f;
    // Start is called before the first frame update
    void Awake()
    {
       SpawnEnemy(); 
    }

    // Update is called once per frame
    void SpawnEnemy()
    {
        if (spawnPoints.Length == 0 || enemyPrefab.Length == 0)
        {
            Debug.LogError("Spawn points or enemy prefabs not assigned.");
            return;
        }
        foreach (Transform spawnPoint in spawnPoints){
            bool rareEnemy = (Random.Range(0f, 1f)<= spawnChance);
            GameObject enemyToSpawn;
            if (rareEnemy && enemyPrefab.Length > 0){
                enemyToSpawn = enemyPrefab[0];
            }
            else{
                int randomIndex = Random.Range(1, enemyPrefab.Length);
                enemyToSpawn = enemyPrefab[randomIndex];
            }
            GameObject spawnedEnemy = Instantiate(enemyToSpawn, spawnPoint.position, Quaternion.identity, transform);
            Messenger<GameObject>.Broadcast(GameEvent.ENEMY_SPAWN, spawnedEnemy);
        }
    }
}
