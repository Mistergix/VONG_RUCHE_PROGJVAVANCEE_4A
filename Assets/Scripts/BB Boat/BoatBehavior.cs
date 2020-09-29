using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoatBehavior : MonoBehaviour
{
    [SerializeField]
    [Range(1, 50)]
    [Tooltip("Max = 1, puis décroissant")]
    private int priority;

    public int Priority { get => priority; }

    public abstract void Execute();
}
