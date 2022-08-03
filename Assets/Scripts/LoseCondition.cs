using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCondition : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if(other.tag != "Player") return;
        if(FindObjectOfType<GameManager>() && FindObjectOfType<TimerClass>()) {
            FindObjectOfType<TimerClass>().Finish();
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
