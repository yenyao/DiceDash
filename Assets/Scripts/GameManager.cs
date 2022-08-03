using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool hasGameEnded = false;
    public float restartDelay = 1f;
    public PlayerMovement PlayerMovement;
    public GameObject GameOverUI;
    public void EndGame() {
        if(!hasGameEnded)
        {
            hasGameEnded = true;
            GameOverUI.SetActive(true);
            Invoke("FreezePlayer", restartDelay);
        }
    }

    void FreezePlayer() {
        PlayerMovement.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
    }
}
