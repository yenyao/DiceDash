using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private MenuService menuService;
    void Start() {
        menuService = gameObject.AddComponent(typeof(MenuService)) as MenuService;
    }
    public void PlayGame() {
        menuService.NextLevel();
    }
    public void QuitGame() {
       menuService.QuitGame();
    }
}
