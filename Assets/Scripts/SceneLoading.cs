using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    [SerializeField]
    private string menuScene = "Menu";
    [SerializeField]
    private string gameScene = "Main";
    [SerializeField]
    private string gameOverScene = "Game Over";

    public void LaunchGame()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(menuScene);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(gameOverScene);
    }

    public void OnApplicationQuit() {
        Application.Quit();
    }
}