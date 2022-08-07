using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    float restartDelay = 0.4f;
    private MenuService menuService;
    public GameObject GameOverUI;
    public TextMeshProUGUI highScoreText;
    private ScoreService scoreService;
    void Start() {
        scoreService = gameObject.AddComponent(typeof(ScoreService)) as ScoreService;
        menuService = gameObject.AddComponent(typeof(MenuService)) as MenuService;
        GameOverUI.SetActive(false);
    }
    public void Restart() {
        Invoke("reloadScene", restartDelay);
    }
    public void QuitGame() {
       menuService.QuitGame();
    }

    void reloadScene() {
        menuService.reloadScene();
    }
    public void setHighScoreText(float highScoreTime) {
        // float highScore = 99999;
        float highScore = highScoreTime;
        highScoreText.text = scoreService.formatTime(highScore);
    }
}
