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
    public void LaunchGame() {
        data.SetLeftAgentType(leftDD.value);
        data.SetRightAgentType(rightDD.value);
        sceneLoading.LaunchGame();
    }

    public void QuitGame() {
        sceneLoading.Quit();
    }

    public void Options() {
        blocker.gameObject.SetActive(!blocker.gameObject.activeSelf);
        if (settingsMenu.gameObject.activeSelf) {
            StartCoroutine(ActivePanel());
        } else {
            settingsMenu.gameObject.SetActive(!settingsMenu.gameObject.activeSelf);
        }
        animOptions.SetTrigger("Open");
    }

    IEnumerator ActivePanel() {
        yield return new WaitForSeconds(1f);
        settingsMenu.gameObject.SetActive(!settingsMenu.gameObject.activeSelf);
    }
}
