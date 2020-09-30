using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bonus Event", menuName = "Event/Bonus Event", order = 51)]
public class BonusEvent : ScriptableObject
{
    private List<BonusEventListener> listeners = new List<BonusEventListener>();

    public void Raise(Player affectedPlayer)
    {
        foreach (var listener in listeners)
        {
            listener.OnEventRaised(affectedPlayer);
        }
    }

    public void RegisterListener(BonusEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(BonusEventListener listener)
    {
        listeners.Remove(listener);
    }
}
