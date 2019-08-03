using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnOffCondition : BaseCondition
{
    
    private bool IsMet;

    public UnityEvent OnEvent;
    public UnityEvent OffEvent;

    void Start()
    {
        IsMet = false;
    }
    public void Toggle()
    {
        if(IsMet)
        {
            //off event
            OffEvent.Invoke();
        }
        else
        {
            //on event
            OnEvent.Invoke();
        }
        IsMet = !IsMet;
    }
    override public bool ConditionIsMet()
    {
        return IsMet;
    }
}
