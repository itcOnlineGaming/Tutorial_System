using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialServiceLocator
{
    private static TutorialEventManager _eventManager;
    public static TutorialEventManager TutorialEventManager
    {
        get
        {
            if (_eventManager == null)
            {
                _eventManager = TutorialEventManager.Instance;
            }
            return _eventManager;
        }
    }
}
