using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float center;
    float amplitude = .1f;
    float frequency = .05f;
    Vector2 pos;
   
    // Update is called once per frame
    void FixedUpdate()
    {
        center = transform.position.y;
        pos = transform.position;
        float sin = Mathf.Sin(pos.x * frequency) * amplitude;
        pos.y = sin + center;
        transform.position = pos;
    }
}
