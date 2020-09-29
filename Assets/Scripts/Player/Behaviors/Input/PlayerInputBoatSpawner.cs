using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputBoatSpawner : PlayerBoatSpawner
{
    [SerializeField]
    private KeyCode spawnKey;

    public void SetKeys(KeyCode spawn)
    {
        spawnKey = spawn;
    }

    protected override bool ShouldSpawn()
    {
        return Input.GetKeyDown(spawnKey);
    }
}
