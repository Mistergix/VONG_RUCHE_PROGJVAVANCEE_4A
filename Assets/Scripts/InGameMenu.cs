using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject inGameMenu;

    private bool shown;
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
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            MenuToggle();
        }
    }


}
