using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStats : EnemyStats
{
    private float _maxHealth;
    private bool _75PercentDropped = false;
    private bool _50PercentDropped = false;
    private bool _25PercentDropped = false;
    protected override void Awake(){
        base.Awake();
        _maxHealth = enemyData.Health;

    }
    public override void TakeDamage(float dmg){
        base.TakeDamage(dmg);
        float healthPercent = currHealth / _maxHealth;
        if (!_75PercentDropped && healthPercent <= 0.75f){
            DropBuff();
            _75PercentDropped = true;
        }
        else if (!_50PercentDropped && healthPercent <= 0.5f){
            DropBuff();
            _50PercentDropped = true;
        }
        else if (!_25PercentDropped && healthPercent <= 0.25f){
            DropBuff();
            _25PercentDropped = true;
        }
    }
    public override void Kill(){
        Destroy(gameObject);
        Messenger<int>.Broadcast(GameEvent.UPDATE_SCORE, currScore);
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Messenger.Broadcast(GameEvent.BOSS_DEATH);
   }

   private void DropBuff(){
            int randomIndex = Random.Range(0, drops.Length);
            Instantiate(drops[randomIndex], transform.position, Quaternion.identity);
   }
}
