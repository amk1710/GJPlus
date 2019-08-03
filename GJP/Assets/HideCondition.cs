using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HideCondition : BaseCondition
{
    private bool PlayerIsHidden;

    private PlayerMovement playerMovement;

    public UnityEvent HideEvent;
    public UnityEvent UnhideEvent;

    // Start is called before the first frame update
    void Start()
    {
        PlayerIsHidden = false;
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    public void ToggleHidePlayer()
    {
        if(PlayerIsHidden)
        {
            UnhideEvent.Invoke();
        }
        else
        {
            HideEvent.Invoke();

        }
        PlayerIsHidden = !PlayerIsHidden;
        playerMovement.SetHidden(PlayerIsHidden);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public bool ConditionIsMet()
    {
        return PlayerIsHidden;
    }

}
