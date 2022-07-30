using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject gameManager;
    
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            gameManager.GetComponent<TimerClass>().Finish();
            gameObject.transform.parent.Find("Confetti").GetComponent<ParticleSystem>().Play();
        }
    }
}
