using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInitializer : MonoBehaviour
{
    [SerializeField]
    private InitializationData initializationData;

    [SerializeField]
    private Transform leftSpawn, rightSpawn;

    [SerializeField]
    private GameOver gameOverManager;

    // Start is called before the first frame update
    void Start()
    {
        GameObject lPlayer = Instantiate(initializationData.LeftPlayerPrefab, leftSpawn.position, Quaternion.identity);
        GameObject rPlayer = Instantiate(initializationData.RightPlayerPrefab, rightSpawn.position, Quaternion.identity);

        lPlayer.GetComponent<Player>().Init(initializationData.LeftPlayerData);
        rPlayer.GetComponent<Player>().Init(initializationData.RightPlayerData);

        gameOverManager.Init(lPlayer.GetComponent<Player>(), rPlayer.GetComponent<Player>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
