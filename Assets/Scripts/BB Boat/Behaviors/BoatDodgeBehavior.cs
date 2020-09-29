using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatDodgeBehavior : BoatBehavior
{
    /// <summary>
    /// UNE SEULE FOIS, si le bateau détecte un autre BB Boat ou un danger va à gauche ou a droite (on peut tirer un raycast devant pour détecter un objet )
    /// </summary>
    public override void Execute()
    {
        Debug.Log("PAS IMPLEMENTE : J'ESQUIVE");
    }
}
