using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuService  : MonoBehaviour
{
    public void QuitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void reloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}