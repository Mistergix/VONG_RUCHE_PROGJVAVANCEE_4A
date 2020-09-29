using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRandomMovement : PlayerMovement
{
    protected override Vector3 Direction()
    {
        return Random.value < 0.5f ? Vector3.forward : Vector3.back;
    }
}
