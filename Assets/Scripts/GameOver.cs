using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    float restartDelay = 0.4f;
    public void Restart() {
        Invoke("reloadScene", restartDelay);
    }
    public void QuitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }

    void reloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
