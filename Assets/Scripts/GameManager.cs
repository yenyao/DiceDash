using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    bool _isGameOver = false;
    public TextMeshProUGUI playTimerText;
    public float restartDelay = 1f;
    private ScoreService scoreService;
    private float endTime;
    void Start() {
        scoreService = gameObject.AddComponent(typeof(ScoreService)) as ScoreService;
    }
    void Update() {
        if(_isGameOver) return;
        endTime = timeTaken();

        string elapsedTime = scoreService.formatTime(endTime);

        playTimerText.text = elapsedTime;
    }
    float timeTaken() {
        return Time.timeSinceLevelLoad * 1000;
    }

    public void endGame() {
        if(!_isGameOver)
        {
            _isGameOver = true;
        }
    }

    public float getEndTime() {
        return endTime;
    }

    public void win() {
        float highScore = scoreService.getHighScore();
        _isGameOver = true;
        playTimerText.color = Color.yellow;
        if (endTime < highScore || highScore == 0f) {
            scoreService.setHighScore(endTime);
        }
        endTime = 0f;
    }
    public void lose() {
        _isGameOver = true;
        float highScore = scoreService.getHighScore();
        playTimerText.color = Color.yellow;
        endTime = 0f;
    }
}
