
using System;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEventManager
{
    private Dictionary<Event, Delegate> eventListeners = new Dictionary<Event, Delegate>();

    public void Subscribe(Event gameEvent, Action<Transform> listener)
    {
        if (!eventListeners.ContainsKey(gameEvent))
        {
            eventListeners[gameEvent] = null;
        }
        eventListeners[gameEvent] = (Action<Transform>)eventListeners[gameEvent] + listener;
    }
    public void Subscribe(Event gameEvent, Action<Transform, PopUpData> listener)
    {
        if (!eventListeners.ContainsKey(gameEvent))
        {
            eventListeners[gameEvent] = null;
        }
        eventListeners[gameEvent] = (Action<Transform, PopUpData>)eventListeners[gameEvent] + listener;
    }

    public void RaiseEvent(Event gameEvent, Transform eventData)
    {
        if (eventListeners.ContainsKey(gameEvent) && eventListeners[gameEvent] is Action<Transform> action)
        {
            action.Invoke(eventData);
        }
    }
    public void RaiseEvent(Event gameEvent, Transform eventData, PopUpData data)
    {
        if (eventListeners.ContainsKey(gameEvent) && eventListeners[gameEvent] is Action<Transform, PopUpData> action)
        {
            action.Invoke(eventData, data);
        }
    }
}
