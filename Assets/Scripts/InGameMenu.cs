using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject inGameMenu;
    [SerializeField]
    private Image optionPanel;

    private bool shown;

    [SerializeField]
    private GameEvent pause;
    // Start is called before the first frame update
    void Start()
    {
        shown = true;
        MenuToggle();
    }

    public void MenuToggle()
    {
        shown = !shown;
        inGameMenu.SetActive(shown);
        Time.timeScale = shown ? 0 : 1;
        pause.Raise();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !optionPanel.gameObject.activeSelf)
        {
            MenuToggle();
        }
    }


}
