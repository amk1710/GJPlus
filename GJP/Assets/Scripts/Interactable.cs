using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    private bool playerIsTouching;
    private BaseCondition condition;

    public UnityEvent InteractEvent;
    
    // Start is called before the first frame update
    void Start()
    {
        playerIsTouching = false;
        condition = GetComponent<BaseCondition>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(playerIsTouching);
    }

    public void Interact()
    {
        InteractEvent.Invoke();
        

        if(condition is OnOffCondition)
        {
            OnOffCondition ooc = condition as OnOffCondition;
            ooc.Toggle();
        }
        else if(condition is HideCondition)
        {
            HideCondition hc = condition as HideCondition;
            hc.ToggleHidePlayer();
        }
        //faz corotina pra desligar, se precisar

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter");
        if (other.tag == "Player")
        {
            playerIsTouching = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerIsTouching = false;
        }
    }

    void OnMouseDown()
    {
        //se eu cliquei nesse objeto e estou no range, interajo
        if(playerIsTouching)
        {
            Interact();
        }
    }
}
