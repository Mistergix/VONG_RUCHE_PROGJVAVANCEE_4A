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

    protected override Vector3 Direction()
    {
        if(Input.GetKey(upKey))
        {
            return Vector3.forward;
        }

        if(Input.GetKey(downKey))
        {
            return Vector3.back;
        }

        return Vector3.zero;
    }
}
