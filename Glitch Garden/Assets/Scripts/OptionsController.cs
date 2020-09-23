using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionsController : MonoBehaviour
{

    [SerializeField] Slider volmeSlider;
    [SerializeField] float defaultVolume = 0.8f;

    [SerializeField] Slider difficutySlider;
    [SerializeField] float defaultDifficulty = 0f;

    // Start is called before the first frame update 
    void Start()
    {
        volmeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficutySlider.value = PlayerPrefsController.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volmeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player found, you need to start from splash screen");
        }
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volmeSlider.value);
        PlayerPrefsController.SetDifficulty(difficutySlider.value);
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }

    public void SaveDefaults()
    {
        volmeSlider.value = defaultVolume;
        difficutySlider.value = defaultDifficulty;
    }
}
