using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioMixer myaudiomixertest;
    public Slider volumeSlider;

    void Start()
    {
        // Load saved volume level (if exists)
        if (PlayerPrefs.HasKey("Master"))
        {
            float savedVolume = PlayerPrefs.GetFloat("Master");
             myaudiomixertest = FindFirstObjectByType<AudioMixer>();
              if(myaudiomixertest != null)
               {
            volumeSlider.value = savedVolume;
            SetVolume(savedVolume);
             }
        }
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
        PlayerPrefs.SetFloat("Master", volume); // Save volume setting
    }
}
