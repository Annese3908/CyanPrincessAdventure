using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public Enemy enemyData;
    public GameObject explosionPrefab;
    public GameObject[] drops;
    // Current Stats
    protected float currHealth;
    protected float currDamage;
    protected int currScore;
    float dropChance = 0.3f;
    // Start is called before the first frame update
    protected virtual void Awake()
    {
        currHealth = enemyData.Health;
        currDamage = enemyData.Damage;
        currScore = enemyData.Score;
    }

    // Update is called once per frame
    public virtual void TakeDamage(float dmg)
    {
        currHealth -= dmg;

        if (currHealth <= 0){
            Kill();
        }
    }
    public virtual void Kill(){
        if (drops != null && Random.value <= dropChance){
            int randomIndex = Random.Range(0, drops.Length);
            GameObject dropPrefab = drops[randomIndex];
            Instantiate(dropPrefab, transform.position, Quaternion.identity);
        }
        Messenger<GameObject>.Broadcast(GameEvent.ENEMY_DEATH, gameObject);
        Destroy(gameObject);
        Messenger<int>.Broadcast(GameEvent.UPDATE_SCORE, currScore);
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }
}