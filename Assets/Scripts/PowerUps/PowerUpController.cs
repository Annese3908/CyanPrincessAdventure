using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public PowerUp powerUpData;
    // Start is called before the first frame update
   void OnTriggerEnter2D(Collider2D col){
    if(col.CompareTag("Player")){
        powerUpData.Apply(col.gameObject);
        Destroy(gameObject);
    }
    if (col.CompareTag("Boundary(Bott)")){
            Destroy(gameObject);
        }
   }

   void Update(){
    transform.Translate(Vector2.down * 2 * Time.deltaTime);
   }
}
