using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Player playerData;
    public GameObject explosionPrefab;
    float currHealth;
    //int currScore;
    int currLives;
    int maxLives = 5;
    public Image[] lives;

    // Start is called before the first frame update

    void Awake(){
        currHealth = playerData.Health;
        currLives = playerData.Lives;
        UpdateLivesUI();
    }

    void UpdateLivesUI()
    {
        // Disable all lives first
        for (int i = 0; i < lives.Length; i++)
        {
            lives[i].enabled = false;
        }

        // Enable only up to currLives
        for (int i = 0; i < currLives; i++)
        {
            if (i < lives.Length) // Prevent out-of-bounds
            {
                lives[i].enabled = true;
            }
        }
    }

    public void TakeDamage(float dmg)
    {
        currHealth -= dmg;
        if (currHealth <= 0)
        {
            currLives--;
            UpdateLivesUI();
            if (currLives <= 0)
            {
                Kill();
            }
            else
            {
                currHealth = playerData.Health;
            }
        }
    }

    public void Kill(){
        Destroy(gameObject);
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Messenger.Broadcast(GameEvent.PLAYER_DEATH);
        Debug.Log("Game Over! No lives remaining.");
    }

    public void AddLife()
    {
        if (currLives < maxLives) // Cap at 5 lives
        {
            currLives++;
            UpdateLivesUI();
        }
    }
}
