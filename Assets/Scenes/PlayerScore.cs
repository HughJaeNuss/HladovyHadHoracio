using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 
using TMPro;
using System.Collections;
using System.Collections.Generic;


public class PlayerScore : MonoBehaviour

{
   
    public float highestScore = 0;
    public float lastScore;
    //public TMP_Text PlayerScoreText;
    public TextMeshProUGUI PlayerScoreText;
    //public TMP_Text highestScoreText;
    //public TMP_Text finalScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartScore()
    {
       lastScore = 0;
       if (PlayerPrefs.HasKey("highestScore"))
        {
       highestScore = PlayerPrefs.GetFloat("highestScore");
       PlayerScoreText.text = "SCORE:" + PlayerPrefs.GetFloat("highestScore").ToString();
       }
       else
        {
       PlayerScoreText.text = "SCORE:" + lastScore.ToString();
       }
    }

    // Update is called once per frame, we do not use it, is therefore deleted
    public void UpdateScore(float lastscore)
    {
        // Did the player save any highestScore yet? 
        if (PlayerPrefs.HasKey("highestScore"))
        {
            if (lastScore > PlayerPrefs.GetFloat("highestScore"))
            //When highestScore exists but the lastscore is better than highestScore, save the new highestScore from the lastScore
               {
                   PlayerPrefs.SetFloat("highestScore", lastScore);
                   PlayerPrefs.Save();        
               }
            else
               {
               // If highestScore better than lastScore, the highestScore is already set, do nothing    
               }
               
        } 
        else
        // If no highestScore saved yet, set it from lastscore
           {
           PlayerPrefs.SetFloat("highestScore", lastScore);
           PlayerPrefs.Save();    
           }
        // In all cases read the highestScore to PlayerScoreText as the highestScore was just updated
               PlayerScoreText.text = "SCORE:" + PlayerPrefs.GetFloat("highestScore").ToString();
       }
       
}

