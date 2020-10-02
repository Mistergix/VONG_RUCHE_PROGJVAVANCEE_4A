using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixerBGM;
    [SerializeField]
    private AudioMixer audioMixerSFX;
    [SerializeField]
    private MainMenu mm;

    public void SetVolumeBGM(float volume) {
        audioMixerBGM.SetFloat("VolumeBGM", volume);
        PlayerPrefs.SetFloat("backgroundVolume", volume);
    }

    public void SetVolumeSFX(float volume) {
        audioMixerSFX.SetFloat("VolumeSFX", volume);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
}
