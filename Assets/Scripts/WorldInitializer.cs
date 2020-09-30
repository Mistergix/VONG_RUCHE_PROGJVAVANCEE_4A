using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInitializer : MonoBehaviour
{
    [SerializeField]
    private PlayerUI leftUI, rightUI;

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

        Player lp = lPlayer.GetComponent<Player>();
        Player rp = rPlayer.GetComponent<Player>();

        lp.Init(initializationData.LeftPlayerData);
        rp.Init(initializationData.RightPlayerData);

        leftUI.Init(lp);
        rightUI.Init(rp);

        gameOverManager.Init(lp, rp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
