using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ScoreService : MonoBehaviour
{
    private float highScore;

    public float getHighScore() {
        return PlayerPrefs.GetFloat("HighScore");
    }
    public void setHighScore(float score) {
        PlayerPrefs.SetFloat("HighScore", 9999999999);
    }
    
    public string formatTime( float time )
    {
        int minutes = (int) time / 60000 ;
        int seconds = (int) time / 1000 - 60 * minutes;
        int milliseconds = ((int) time - minutes * 60000 - 1000 * seconds)/10;
        return string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }
}
