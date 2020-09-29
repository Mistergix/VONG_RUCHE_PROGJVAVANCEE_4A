using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoatForwardBehavior : BoatBehavior
{
    [SerializeField]
    private float speed;
    private Boat boat;

    private void Start() {
        boat = GetComponent<Boat>();
    }
    /// <summary>
    /// Le bateau avance à une certaine vitesse (attention à la direction initiale (gauche ou droite))
    /// </summary>
    public override void Execute()
    {
        transform.position += boat.Direction() * speed * Time.deltaTime;
    }
}
