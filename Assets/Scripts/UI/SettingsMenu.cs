using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolumeBGM(float volume) {
        audioMixer.SetFloat("VolumeBGM", volume);
    }

    public void SetVolumeSFX(float volume) {
        audioMixer.SetFloat("VolumeSFX", volume);
    }
}
