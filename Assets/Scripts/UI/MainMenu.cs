using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    [SerializeField]
    private Dropdown leftDD, rightDD;

    [SerializeField]
    private SceneLoading sceneLoading;

    [SerializeField]
    private InitializationData data;

    [SerializeField]
    private Animator animOptions;

    [SerializeField]
    private Image settingsMenu;

    [SerializeField]
    private Image blocker;

    public Slider backgroundSlider;
    public Slider SFXSlider;

    private void Start() {
        backgroundSlider.value = PlayerPrefs.GetFloat("backgroundVolume", 0f);
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0f);
    }
    public void LaunchGame() {
        data.SetLeftAgentType(leftDD.value);
        data.SetRightAgentType(rightDD.value);
        sceneLoading.LaunchGame();
    }

    public void QuitGame() {
        sceneLoading.Quit();
    }

    public void Options() {
        if (settingsMenu.gameObject.activeSelf) {
            StartCoroutine(ActivePanel());
        } else {
            settingsMenu.gameObject.SetActive(!settingsMenu.gameObject.activeSelf);
            blocker.gameObject.SetActive(!blocker.gameObject.activeSelf);
        }
        animOptions.SetTrigger("Open");
    }

    IEnumerator ActivePanel() {
        yield return new WaitForSecondsRealtime(.5f);
        settingsMenu.gameObject.SetActive(!settingsMenu.gameObject.activeSelf);
        blocker.gameObject.SetActive(!blocker.gameObject.activeSelf);
    }
}
