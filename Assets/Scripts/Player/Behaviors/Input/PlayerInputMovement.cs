using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputMovement : PlayerMovement
{
    private KeyCode upKey, downKey;

    public void SetKeys(KeyCode up, KeyCode down)
    {
        upKey = up;
        downKey = down;
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
