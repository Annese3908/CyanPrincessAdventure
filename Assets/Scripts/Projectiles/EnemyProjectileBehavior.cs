using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileBehavior : ProjectileBehavior
{
    protected override void Update()
    {
        transform.Translate(Vector2.down * currSpeed * Time.deltaTime);
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
