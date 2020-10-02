using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverTitle : MonoBehaviour
{
    [SerializeField]
    private GameData mainData;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = string.Format("{0} won !", mainData.LeftWon ? "Left" : "Right");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
