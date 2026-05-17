using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Start()
    {

        // Load saved audio settings
        float masterVol = PlayerPrefs.GetFloat("MasterVol", 1f);
        float musicVol = PlayerPrefs.GetFloat("MusicVol", 1f);
        float sfxVol = PlayerPrefs.GetFloat("SFXVol", 1f);

        AudioManager.Instance.SetMasterVolume(masterVol);
        AudioManager.Instance.SetMusicVolume(musicVol);
        AudioManager.Instance.SetSFXVolume(sfxVol);
        AudioManager.Instance.PlayMusic(AudioManager.Instance.backgroundMusic);

        // Load saved resolution
        int resIndex = PlayerPrefs.GetInt("ResIndex", 0);
        Resolution[] resolutions = Screen.resolutions;
        if (resIndex >= 0 && resIndex < resolutions.Length)
        {
            Resolution res = resolutions[resIndex];
            Screen.SetResolution(res.width, res.height, Screen.fullScreen);
        }
    }

    public void LoadWinScene() => SceneManager.LoadScene("WinScene");
    public void RestartGame() => SceneManager.LoadScene("Level1");
    public void LoadLoseScene() => SceneManager.LoadScene("LoseScene");
    public void QuitGame() => Application.Quit();
}
