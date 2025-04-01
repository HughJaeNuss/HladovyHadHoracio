using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class Stopwatch : MonoBehaviour
{
    public float elapsedTime = 0; // Time elapsed since the game started
    public bool timerRunning = false; 
    public TextMeshProUGUI timerText; // Assign in Inspector
    //public TMP_Text PlayerScoreText;
    public TextMeshProUGUI PlayerScoreText; 
    public float finalScore;
    public static float lastScore;
    public PlayerScore score;

    void Update()
    {
        if (timerRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerDisplay(elapsedTime); 
        }
    }

    void UpdateTimerDisplay(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StartTimer()
    {
        //Debug.LogError("Stopwatch::StartTimer ... " + timerRunning);
        if (!timerRunning) // Start the timer only once
        {
            timerRunning = true;
        }
    
    }
    
    public void StopTimer() // Call this when the game ends
    {
        timerRunning = false;
        finalScore = elapsedTime;
        PlayerPrefs.SetFloat("lastScore", finalScore);
        PlayerPrefs.Save();
        //Debug.LogError("Stopwatch::StopTimer event:" + finalScore.ToString());
        //score.Update("SCORE: " + lastscore);
        //PlayerScoreText.text = "SCORE:" + finalScore.ToString(); //Tohle funguje, ale na snake obrazovku, když dám PlayerScoreText jako TMP Text v Inspektorovi. S NONE typem had leze ven z obrazovky.
        //score.UpdateScore(finalScore);
    }
}
