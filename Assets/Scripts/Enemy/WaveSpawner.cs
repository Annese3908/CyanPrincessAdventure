using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject Boss;
    public GameObject enemyGrid;
    public int maxWaves = 5;
    private List<GameObject> activeEnemies = new List<GameObject>();
    private int _currWave = 0;

    public void Start(){
        SpawnWave();
    }

    private void OnEnable(){
        Messenger<GameObject>.AddListener(GameEvent.ENEMY_SPAWN, RegisterEnemy);
        Messenger<GameObject>.AddListener(GameEvent.ENEMY_DEATH, UnregisterEnemy);
    }
    private void OnDisable(){
        Messenger<GameObject>.RemoveListener(GameEvent.ENEMY_SPAWN, RegisterEnemy);
        Messenger<GameObject>.RemoveListener(GameEvent.ENEMY_DEATH, UnregisterEnemy);
    }
    
    public void RegisterEnemy(GameObject enemy){
        activeEnemies.Add(enemy);
    }
    public void UnregisterEnemy(GameObject enemy){
        activeEnemies.Remove(enemy);
        if (activeEnemies.Count == 0){
            SpawnWave();
        }
    }

    public void SpawnWave(){
         _currWave++;
        if (_currWave > maxWaves){
            Debug.Log("All waves complete! Boss Incoming!");
            SpawnBoss();
            return;
        }
        GameObject newWave = Instantiate(enemyGrid, transform.position, Quaternion.identity);
        Messenger<int, int>.Broadcast(GameEvent.NEW_WAVE, _currWave, maxWaves);
    }
    public void SpawnBoss(){
        Instantiate (Boss, transform.position, Quaternion.identity);
    }


}
