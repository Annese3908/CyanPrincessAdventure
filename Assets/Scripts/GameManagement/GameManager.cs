using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    int _score;
    public TMP_Text scoreText;
    public GameConditionUI gameOverScreen;
    public GameConditionUI gameWonScreen;
    public TMP_Text waveText;

    private void OnEnable(){
        Messenger<int>.AddListener(GameEvent.UPDATE_SCORE, UpdateScore);
        Messenger<int, int>.AddListener(GameEvent.NEW_WAVE, UpdateWave);
        Messenger.AddListener(GameEvent.PLAYER_DEATH, GameLost);
        Messenger.AddListener(GameEvent.BOSS_DEATH, GameWon);
    }
    private void OnDisable(){
        Messenger<int>.RemoveListener(GameEvent.UPDATE_SCORE, UpdateScore);
        Messenger<int, int>.RemoveListener(GameEvent.NEW_WAVE, UpdateWave);
         Messenger.RemoveListener(GameEvent.PLAYER_DEATH, GameLost);
         Messenger.RemoveListener(GameEvent.BOSS_DEATH, GameWon);
    }

    private void GameLost(){
        gameOverScreen.Setup(_score);
    }
    private void GameWon(){
        gameWonScreen.Setup(_score);
    }
    public void UpdateWave(int waves, int maxWaves){
        waveText.text = "Wave: " + waves.ToString() + "/" + maxWaves.ToString();

        if (waves > maxWaves){
            waveText.text = "BOSS INCOMING!!!";
            //spawn boss
        }
    }
    public void UpdateScore(int points){
        _score += points;
        scoreText.text = "Score: " + _score.ToString();
    }
}

