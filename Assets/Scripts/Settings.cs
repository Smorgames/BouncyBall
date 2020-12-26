using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private Slider _qualitySlider;

    private float volume = 0;

    private void Start()
    {
        SetLoadQuality();
        SetLoadVolume();
    }

    private void SetLoadQuality()
    {
        if (_qualitySlider != null)
            _qualitySlider.value = PlayerPrefs.GetInt("Quality");
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality"));
    }
    
    private void SetLoadVolume()
    {
        if (_volumeSlider != null)
            _volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        AudioManager.instance.SetVolume(PlayerPrefs.GetFloat("Volume"));
    }

    public void SetQuality(float qualityIndex)
    {
        QualitySettings.SetQualityLevel((int)qualityIndex);
        PlayerPrefs.SetInt("Quality", (int)qualityIndex);
    }

    public void SetVolume(float volume)
    {
        AudioManager.instance.SetVolume(volume);
        PlayerPrefs.SetFloat("Volume", volume);
    }
}