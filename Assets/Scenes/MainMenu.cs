using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour
{

    public string sceneName;
    public void PlayGame()
    {
        SceneManager.LoadScene("Snake", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in Unity Editor
        #else
            Application.Quit(); // Quit in a built game
        #endif
    }

}
