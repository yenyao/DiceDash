using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject TimeObj;
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            TimeObj.GetComponent<TimerClass>().Finish();
        }
    }
}
