using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField]
    private GameEvent eventListened;
    [SerializeField]
    private UnityEvent response;
    public GameEvent EventListened { get => eventListened; private set => eventListened = value; }
    public UnityEvent Response { get => response; private set => response = value; }

    private void OnEnable()
    {
        EventListened.RegisterListener(this);
    }

    private void OnDisable()
    {
        EventListened.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        Response.Invoke();
    }
}
