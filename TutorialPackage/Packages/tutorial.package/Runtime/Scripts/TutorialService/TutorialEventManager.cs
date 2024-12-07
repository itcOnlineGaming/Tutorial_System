using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TutorialEventManager : MonoBehaviour
{
    private Dictionary<TutorialEvent, Delegate> eventListeners = new Dictionary<TutorialEvent, Delegate>();

    private static TutorialEventManager _instance;
    public static TutorialEventManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<TutorialEventManager>();

                if (_instance == null)
                {
                    GameObject em = new GameObject("TutorialEventManager");
                    _instance = em.AddComponent<TutorialEventManager>();

                    DontDestroyOnLoad(em);
                }
            }

            return _instance;
        }
    }
    public void Subscribe(TutorialEvent gameEvent, Action<Transform, PopUpData> listener)
    {
        if (!eventListeners.ContainsKey(gameEvent))
        {
            eventListeners[gameEvent] = null;
        }
        eventListeners[gameEvent] = (Action<Transform, PopUpData>)eventListeners[gameEvent] + listener;
    }

    public void Subscribe(TutorialEvent gameEvent, Action<Transform, ArrowPopUpData> listener)
    {
        if (!eventListeners.ContainsKey(gameEvent))
        {
            eventListeners[gameEvent] = null;
        }
        eventListeners[gameEvent] = (Action<Transform, ArrowPopUpData>)eventListeners[gameEvent] + listener;
    }

    public void Subscribe(TutorialEvent gameEvent, Action<Transform, SwipePopUpData> listener)
    {
        if (!eventListeners.ContainsKey(gameEvent))
        {
            eventListeners[gameEvent] = null;
        }
        eventListeners[gameEvent] = (Action<Transform, SwipePopUpData>)eventListeners[gameEvent] + listener;
    }
    public void RaiseEvent(TutorialEvent gameEvent, Transform eventData, PopUpData data)
    {
        if (eventListeners.ContainsKey(gameEvent) && eventListeners[gameEvent] is Action<Transform, PopUpData> action)
        {
            action.Invoke(eventData, data);
        }
    }

    public void RaiseEvent(TutorialEvent gameEvent, Transform eventData, ArrowPopUpData data)
    {
        if (eventListeners.ContainsKey(gameEvent) && eventListeners[gameEvent] is Action<Transform, ArrowPopUpData> action)
        {
            action.Invoke(eventData, data);
        }
    }

    public void RaiseEvent(TutorialEvent gameEvent, Transform eventData, SwipePopUpData data)
    {
        if (eventListeners.ContainsKey(gameEvent) && eventListeners[gameEvent] is Action<Transform, SwipePopUpData> action)
        {
            action.Invoke(eventData, data);
        }
    }
}
