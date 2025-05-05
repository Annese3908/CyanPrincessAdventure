using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Boundary")){
            transform.position = new Vector3(transform.position.x, transform.position.y - .75f, transform.position.z);
            moveSpeed *= -1;
        }
    }
}
