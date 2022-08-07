using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCondition : MonoBehaviour
{
    public GameObject gameOverUI;
    private ScoreService scoreService;
    
    void Start() {
        scoreService = gameObject.AddComponent(typeof(ScoreService)) as ScoreService;
    }
    void OnTriggerEnter(Collider other) {
        if(other.tag != "Player") return;
        if(FindObjectOfType<GameManager>()) {
            float highScore = scoreService.getHighScore();
            gameOverUI.SetActive(true);
            FindObjectOfType<GameManager>().lose();
            FindObjectOfType<GameManager>().endGame();
            FindObjectOfType<PlayerMovement>().FreezePlayer();
            FindObjectOfType<GameOver>().setHighScoreText(highScore);
        }
    }
}
