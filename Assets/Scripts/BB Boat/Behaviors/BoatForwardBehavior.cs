using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoatForwardBehavior : BoatBehavior
{
    private float speed;
    private Boat boat;

    public float Speed { get => speed; set => speed = value; }
 
    private void Start() {
        boat = GetComponent<Boat>();
    }
    /// <summary>
    /// Le bateau avance à une certaine vitesse (attention à la direction initiale (gauche ou droite))
    /// </summary>
    public override void Execute()
    {
        transform.position += boat.Direction() * Speed * Time.deltaTime;
    }
}
