using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectileBehavior : ProjectileBehavior
{
    public float lifeTime = 5f;
    float timer = 0f;

    protected override void Update()
    {
       if (timer > lifeTime){
        Destroy(gameObject);
       }
       timer += Time.deltaTime;
       transform.position += (Vector3)((Vector2)transform.right * currSpeed * Time.deltaTime);
    }

    protected override void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag("Player")){
            PlayerStats player = col.GetComponent<PlayerStats>();
            player.TakeDamage(currDamage);
            Destroy(gameObject);
        }
        if (col.CompareTag("Boundary(Bott)")){
            Destroy(gameObject);
        }
        if (col.CompareTag("Boundary(Top)")){
            Destroy(gameObject);
        }
    }
}
