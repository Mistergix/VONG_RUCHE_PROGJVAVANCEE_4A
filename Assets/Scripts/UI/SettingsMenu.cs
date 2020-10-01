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

    public void SetVolumeBGM(float volume) {
        audioMixerBGM.SetFloat("VolumeBGM", volume);
    }

    public void SetVolumeSFX(float volume) {
        audioMixerSFX.SetFloat("VolumeSFX", volume);
    }
}
