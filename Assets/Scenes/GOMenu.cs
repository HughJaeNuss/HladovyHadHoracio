using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 
using System.Collections;
using System.Collections.Generic;
using TMPro;


public class GOMenu : MonoBehaviour
{
public float highestScore = 0;
public float lastScore;
public float eaten;
public TextMeshProUGUI PlayerScoreText = new TextMeshProUGUI();
public TextMeshProUGUI EatenText;
//public PlayerScore score;

string UpdateScoreDisplay(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        string saved_score = string.Format("{0:00}:{1:00}", minutes, seconds);
        return saved_score;
    }
private void Start()
    {
 // Pastička
 /*
   PlayerScoreText = FindFirstObjectByType<TextMeshProUGUI>();
        if (PlayerScoreText)
            Debug.Log("TextMesh object found: " + PlayerScoreText.name);
        else
            Debug.Log("No TextMesh object could be found");
*/
// Initialization  
       //PlayerScoreText = GetComponent<TextMeshProUGUI>();  
       //PlayerScoreText = FindFirstObjectByType<TextMeshProUGUI>();
        //PlayerScoreText.SetActive();
        //GameObject.FindGameObjectWithTag("PlayerController").GetComponent<GOMenu>().PlayerScoreText;
        //GameObject.Find("GOMenu").GetComponent<GOMenu>().PlayerScoreText;
        //PlayerScoreText.GetComponent().enabled = true;
        PlayerScoreText.text = "SCORE: 00:00";
        /*
        GameObject gameObject = GameObject.Find("GOMenu"); 
        if (gameObject != null) {
            Debug.Log("Found GoMenu game object");
        } else {
            Debug.Log("No GoMenu game object");
        }
        if (this.PlayerScoreText != null) {
            this.PlayerScoreText.text = "SCORE: 00:00";
        } else {
            Debug.Log("Player score text is null");
        }
        */
        //EatenText = FindFirstObjectByType<TextMeshProUGUI>();
        //EatenText = GetComponent<TextMeshProUGUI>();    
        EatenText.text = "PINEAPPLE: 0";
// Load saved highestScore
    if (PlayerPrefs.HasKey("highestScore")){
        float highestScore = PlayerPrefs.GetFloat("highestScore", 0);
    }
// Load saved lastScore
    if (PlayerPrefs.HasKey("lastScore")){
        float lastScore = PlayerPrefs.GetFloat("lastScore", 0);
        //float highestScore = PlayerPrefs.GetFloat("highestScore", 0); 
        PlayerScoreText.text = "SCORE: " + UpdateScoreDisplay(lastScore);
    }
      else
    {
        PlayerScoreText.text = "TEXTNENI";
        Debug.LogError("PlayerScoreText is not assigned in the Inspector!");
    }

// Load saved eaten
    if (PlayerPrefs.HasKey("eaten")){
        float eaten = PlayerPrefs.GetFloat("eaten", 0);
        EatenText.text = "PINEAPPLE: " + eaten.ToString();
    }

    else
    {
        PlayerScoreText.text = "TEXTNENI";
        Debug.LogError("EatenText is not assigned in the Inspector!");
    }

    if (lastScore > highestScore)
    {
        PlayerPrefs.SetFloat("highestScore", lastScore);
        PlayerPrefs.Save();
    }
    }
public void TryAgain()
{
    SceneManager.LoadScene("Snake", LoadSceneMode.Single);
    //SceneManager.LoadScene("Snake");
}

public void ReturnToMenu()
{
    SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
}

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
/*
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
 */
}