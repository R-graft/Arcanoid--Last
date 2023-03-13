using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewListenersList", menuName = "EventsData/NewEventsData")]
public class EventListenersList : ScriptableObject
{
    private List<EventListener> _listeners;

    public void AddListener(EventListener listener)
    {
        _listeners.Add(listener);
    }

    public void RemoveListener(EventListener listener)
    {
        _listeners.Remove(listener);
    }

    public void InitAction()
    {
        foreach (var listener in _listeners)
        {
            listener.RiseReaction();
        }
    }
}
