using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputBoatSpawner : PlayerBoatSpawner
{
    private PlayerData playerData;

    private KeyCode spawnKey;

    public void SetKeys(KeyCode spawn)
    {
        spawnKey = spawn;
    }

    public override void Init()
    {
        base.Init();
        playerData = GetComponent<Player>().PlayerDataInstance;
        SetKeys(playerData.Spawn);
    }

    protected override bool ShouldSpawn()
    {
        return Input.GetKeyDown(spawnKey);
    }
}
