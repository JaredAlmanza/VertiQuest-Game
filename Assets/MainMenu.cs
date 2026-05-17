using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsPanel;
    public Dropdown resolutionDropdown;
    public Slider masterSlider, musicSlider, sfxSlider;
    public AudioMixer audioMixer;

    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            resolutionDropdown.options.Add(new Dropdown.OptionData(option));

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.value = PlayerPrefs.GetInt("ResIndex", currentResolutionIndex);
        resolutionDropdown.RefreshShownValue();

        float master = PlayerPrefs.GetFloat("MasterVol", 1f);
        float music = PlayerPrefs.GetFloat("MusicVol", 1f);
        float sfx = PlayerPrefs.GetFloat("SFXVol", 1f);

        masterSlider.value = master;
        musicSlider.value = music;
        sfxSlider.value = sfx;

        SetMasterVolume(master);
        SetMusicVolume(music);
        SetSFXVolume(sfx);
    }

    public void PlayGame()
    {
        PlayerPrefs.Save();
        SceneManager.LoadScene("Level1");
    }

    public void LoadLevel(int levelIndex)
    {
        PlayerPrefs.Save();
        SceneManager.LoadScene("Level" + levelIndex);
    }

    public void QuitGame() => Application.Quit();

    public void OpenOptions() => optionsPanel.SetActive(true);
    public void CloseOptions() => optionsPanel.SetActive(false);

    public void SetResolution(int resolutionIndex)
    {
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
        PlayerPrefs.SetInt("ResIndex", resolutionIndex);
    }

    public void SetMasterVolume(float value)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("MasterVol", value);
    }

    public void SetMusicVolume(float value)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("MusicVol", value);
    }

    public void SetSFXVolume(float value)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("SFXVol", value);
    }
}
