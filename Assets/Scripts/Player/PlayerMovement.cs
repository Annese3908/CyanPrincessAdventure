using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Player playerStats;
    [HideInInspector]
    float moveSpeed;

    bool isPowerUpActive = false;
    Rigidbody2D rb;
    Vector2 moveDir;


    void Awake(){
        moveSpeed = playerStats.Speed;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        InputManagement();
    }
public void SpeedBoost(float multiplier, float duration)
    {
        if (!isPowerUpActive)
        {
            moveSpeed = playerStats.Speed; // Backup original
        }

        // Apply multiplier
        moveSpeed = playerStats.Speed * multiplier;
        isPowerUpActive = true;

        // Schedule revert
        Invoke(nameof(RevertSpeed), duration);
    }

    private void RevertSpeed()
    {
        moveSpeed = playerStats.Speed;
        isPowerUpActive = false;
    }

    // Update is called once per frame
    void FixedUpdate(){
        Move();
    }

    void InputManagement(){
        float deltaX = Input.GetAxis("Horizontal") * moveSpeed;
        float deltaY = Input.GetAxis("Vertical") * moveSpeed/2;

        moveDir = new Vector2(deltaX, deltaY);
    }
    private void Move(){
        rb.velocity = moveDir;
    }
}
