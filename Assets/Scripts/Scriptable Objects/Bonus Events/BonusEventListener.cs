using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusEventListener : MonoBehaviour
{
    [SerializeField]
    private BonusEvent eventListened;
    [SerializeField]
    private BonusUnityEvent response;

    

    public BonusEvent EventListened { get => eventListened; private set => eventListened = value; }
    public BonusUnityEvent Response { get => response; private set => response = value; }

    private void OnEnable()
    {
        EventListened.RegisterListener(this);
    }

    internal void OnEventRaised(Player affectedPlayer)
    {
        response.Invoke(affectedPlayer);
    }

    private void OnDisable()
    {
        EventListened.UnregisterListener(this);
    }
}
