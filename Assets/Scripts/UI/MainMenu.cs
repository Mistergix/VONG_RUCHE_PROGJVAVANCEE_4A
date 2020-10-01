using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Dropdown leftDD, rightDD;

    [SerializeField]
    private SceneLoading sceneLoading;

    [SerializeField]
    private InitializationData data;

    public void LaunchGame()
    {
        data.SetLeftAgentType(leftDD.value);
        data.SetRightAgentType(rightDD.value);
        sceneLoading.LaunchGame();
    }
}
