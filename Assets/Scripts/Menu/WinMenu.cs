using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Should deal with the UI of the win menu
// Display score
// Display high score
// Button functionality
public class WinMenu : MonoBehaviour
{
    public GameObject WinMenuUI;
    private MenuService menuService;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public GameObject PBIcon;
    private ScoreService scoreService;
    private float restartDelay = 0.4f;
    void Start() {
        menuService = gameObject.AddComponent(typeof(MenuService)) as MenuService;
        scoreService = gameObject.AddComponent(typeof(ScoreService)) as ScoreService;
        PBIcon.SetActive(false);
    }
    public void NextLevel() {
        menuService.NextLevel();
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
    public void setScoreText(float scoreTime) {
        float score = scoreTime;
        scoreText.text = scoreService.formatTime(score);
    }
    public void setHighScoreText(float highScoreTime) {
        // float highScore = 99999;
        float highScore = highScoreTime;
        highScoreText.text = scoreService.formatTime(highScore);
    }
    public void activatePBIcon() {
        PBIcon.SetActive(true);
    }
}
