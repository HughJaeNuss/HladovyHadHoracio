using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 

public class SettingsMenu : MonoBehaviour
{
    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
