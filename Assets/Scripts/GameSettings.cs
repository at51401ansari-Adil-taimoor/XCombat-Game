using UnityEngine;
using UnityEngine.UI;


public class GameSettings : MonoBehaviour
{
    public Toggle musicToggle;
    public Slider volumeSlider;
    public AudioSource musicSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bool musicEnabled = PlayerPrefs.GetInt("MusicEnabled", 1) == 1;
        float volume = PlayerPrefs.GetFloat("MusicVolume", 0.7f);

        musicToggle.SetIsOnWithoutNotify(musicEnabled);
        volumeSlider.SetValueWithoutNotify(volume);

        ApplyAudioSettings();

        musicToggle.onValueChanged.AddListener(SetMusic);
        volumeSlider.onValueChanged.AddListener(SetVolume);

    }

        // Update is called once per frame
    void Update()
    {
        
    }

    void ApplyAudioSettings()
    {
        if (musicSource != null)
        {
            musicSource.mute = !musicToggle.isOn;
            musicSource.volume = volumeSlider.value;
        }
    }

    public void SetMusic(bool enabled)
    {
        PlayerPrefs.SetInt("MusicEnabled", enabled ? 1 : 0);
        PlayerPrefs.Save();
        ApplyAudioSettings();
    }


    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();
        ApplyAudioSettings();
    }

    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        PlayerPrefs.Save();

        GameMechanics.highScore = 0;
        Debug.Log("High Score Reset Successfully!");
    }

    void OnDestroy()
    {
        if (musicToggle != null)
            musicToggle.onValueChanged.RemoveListener(SetMusic);

        if (volumeSlider != null)
            volumeSlider.onValueChanged.RemoveListener(SetVolume);
    }

    public static void ApplyMusicSettings(AudioSource source)
    {
        if (source == null) return;

        source.mute = PlayerPrefs.GetInt("MusicEnabled", 1) == 0;
        source.volume = PlayerPrefs.GetFloat("MusicVolume", 0.7f);
    }
}
