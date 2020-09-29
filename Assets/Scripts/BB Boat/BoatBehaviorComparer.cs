using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBehaviorComparer : IComparer<BoatBehavior>
{
    public int Compare(BoatBehavior x, BoatBehavior y)
    {
        return x.Priority - y.Priority;
    }
}