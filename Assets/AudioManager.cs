using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioMixer audioMixer;

    [Header("SFX")]
    public AudioClip arrowShoot;
    public AudioClip swordSwing;
    public AudioClip fireballShoot;
    public AudioClip runStep;
    public AudioClip jump;
    public AudioClip keyPickup;
    public AudioClip doorOpen;

    [Header("Music")]
    public AudioClip backgroundMusic;
    public AudioClip bossMusic;

    private AudioSource sfxSource;
    private AudioSource musicSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            sfxSource = gameObject.AddComponent<AudioSource>();
            musicSource = gameObject.AddComponent<AudioSource>();

            sfxSource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("SFX")[0];
            musicSource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("Music")[0];

            musicSource.loop = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
            sfxSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip != null && musicSource.clip != clip)
        {
            musicSource.clip = clip;
            musicSource.Play();
        }
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void SetMasterVolume(float volume) => audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    public void SetMusicVolume(float volume) => audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    public void SetSFXVolume(float volume) => audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
}
