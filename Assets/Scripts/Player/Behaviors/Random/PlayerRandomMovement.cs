using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRandomMovement : PlayerMovement
{
    protected override float UpDirection()
    {
        float value = Random.value;

        if(value < 1f/3)
        {
            return 0;
        }

        if(value < 2f/3)
        {
            return 1;
        }

        return -1;
    }
}
