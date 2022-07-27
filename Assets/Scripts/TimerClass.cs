using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class TimerClass : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float startTime;
    private bool isFinished = false;
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(isFinished) return;
        float t = Time.time - startTime;

        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;
    }

    public void Finish() {
        isFinished = true;
        timerText.color = Color.yellow;
    }
}
