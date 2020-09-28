using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputMovement : PlayerMovement
{
    [SerializeField]
    private KeyCode upKey, downKey;

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
