using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    float restartDelay = 0.4f;
    private MenuService menuService = new MenuService();
    public void Restart() {
        Invoke("reloadScene", restartDelay);
    }
    public void QuitGame() {
       menuService.QuitGame();
    }

    void reloadScene() {
        menuService.reloadScene();
    }
}
