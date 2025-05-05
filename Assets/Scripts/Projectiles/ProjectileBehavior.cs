using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Predefined Behaviors for projectile weapons
public class ProjectileBehavior : MonoBehaviour
{
    public Projectile data;
    //Current Stats
    protected float currDamage;
    protected float currSpeed;
    // Start is called before the first frame update

    void Awake(){
        currDamage = data.Damage;
        currSpeed = data.Speed;
    }
    // Update is called once per frame
    protected virtual void Update(){
        transform.Translate(Vector2.up * currSpeed * Time.deltaTime);
    }

    protected virtual void OnTriggerEnter2D(Collider2D col){
        // hit enemy
        if(col.CompareTag("Enemy")){
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(currDamage); //must stay currDamage in case of buffs
            Destroy(gameObject);
        }

        if (col.CompareTag("Boundary(Top)")){
            Destroy(gameObject);
        }
    }
}
