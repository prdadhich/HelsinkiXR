using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManage : MonoBehaviour
{


    public delegate void InstantiatorEvent();

    public static event InstantiatorEvent OnInstantiator;


    public delegate void StarCollectorEvent();

    public static event StarCollectorEvent OnStarCollect;


    public delegate void PlayerDieEvent();

    public static event PlayerDieEvent OnPlayerDie;


    public void TriggerInstantiatorEvent()
    {
        if (OnInstantiator != null)
        {
            OnInstantiator();
        }
    }
    public void TriggerStarCollectorEvent()
    {
        if (OnStarCollect != null)

        {
            OnStarCollect();
        }

    }


    public void OnPlayerDieEvent()
    {
        if (OnPlayerDie != null)
        {
            OnPlayerDie();
        }
    }

    
}
