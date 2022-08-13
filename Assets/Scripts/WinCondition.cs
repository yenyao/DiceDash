using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject winMenu;
    private ScoreService scoreService;
    private bool _isHighScore;
    
    void Start() {
        scoreService = gameObject.AddComponent(typeof(ScoreService)) as ScoreService;
        _isHighScore = false;
    }
    
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            activateWinFX();
            FindObjectOfType<GameManager>().win();
            winMenu.SetActive(true);
            setScoreUIText();
            if(scoreService.getIsHighScore() == 1) FindObjectOfType<WinMenu>().activatePBIcon();
        }
    }

    private void setScoreUIText()
    {
        float endTime = FindObjectOfType<GameManager>().getEndTime();
        float highScore = scoreService.getHighScore();
        FindObjectOfType<WinMenu>().setScoreText(endTime);
        FindObjectOfType<WinMenu>().setHighScoreText(highScore);
    }

    void activateWinFX() {
        gameObject.transform.parent.Find("Confetti").GetComponent<ParticleSystem>().Play();
    }
}
