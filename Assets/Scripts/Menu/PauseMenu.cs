using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private MenuService menuService = new MenuService();
    private static bool isPaused = false;
    public GameObject pauseMenuUI;
    private float restartDelay = 0.4f;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(isPaused) Resume();
            else Pause();
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void Restart() {
        Invoke("reloadScene", restartDelay);
        Resume();
    }
    public void QuitGame() {
       menuService.QuitGame();
       Resume();
    }

    void reloadScene() {
        menuService.reloadScene();
    }
}
