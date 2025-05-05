using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameConditionUI : MonoBehaviour
{
    public TMP_Text scoreText;
    public void Setup(int score){
        gameObject.SetActive(true);
        scoreText.text = "Final Score: " + score.ToString();
    }
}
