using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ScoreService : MonoBehaviour
{
    private float highScore;
    private bool _isHighScore;

    public float getHighScore() {
        return PlayerPrefs.GetFloat("HighScore");
    }
    public void setHighScore(float score) {
        PlayerPrefs.SetFloat("HighScore", score);
    }
    
    public void setIsHighScore(int IsHighScore) {
        PlayerPrefs.SetInt("_isHighScore", IsHighScore);
    }
    public int getIsHighScore() {
        return PlayerPrefs.GetInt("_isHighScore");;
    }

    public string formatTime( float time )
    {
        int minutes = (int) time / 60000 ;
        int seconds = (int) time / 1000 - 60 * minutes;
        int milliseconds = ((int) time - minutes * 60000 - 1000 * seconds)/10;
        return string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }
}
