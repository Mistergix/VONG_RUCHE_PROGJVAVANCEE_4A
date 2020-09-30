using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputMovement : PlayerMovement
{
    private PlayerData playerData;

    private KeyCode upKey, downKey;

    public void SetKeys(KeyCode up, KeyCode down)
    {
        upKey = up;
        downKey = down;
    }

    public override void Init()
    {
        base.Init();
        playerData = GetComponent<Player>().PlayerDataInstance;
        SetKeys(playerData.Up, playerData.Down);
    }

    protected override float UpDirection()
    {
        if (Input.GetKey(upKey))
        {
            return 1;
        }

        if (Input.GetKey(downKey))
        {
            return -1;
        }

        return 0;
    }
}
