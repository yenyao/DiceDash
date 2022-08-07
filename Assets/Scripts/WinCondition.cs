using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject winMenu;
    private ScoreService scoreService;
    
    void Start() {
        scoreService = gameObject.AddComponent(typeof(ScoreService)) as ScoreService;
    }
    
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            float endTime = FindObjectOfType<GameManager>().getEndTime();
            float highScore = scoreService.getHighScore();
            FindObjectOfType<GameManager>().win();
            gameObject.transform.parent.Find("Confetti").GetComponent<ParticleSystem>().Play();
            winMenu.SetActive(true);
            Debug.Log("win");
            FindObjectOfType<WinMenu>().setScoreText(endTime);
            FindObjectOfType<WinMenu>().setHighScoreText(highScore);
        }
    }
}
