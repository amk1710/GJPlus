using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    private bool playerIsTouching;
    private BaseCondition condition;

    public UnityEvent InteractEvent;

    private Transform Player;
    
    // Start is called before the first frame update
    void Start()
    {
        playerIsTouching = false;
        condition = GetComponent<BaseCondition>();
        Player = GameObject.FindObjectOfType<PlayerInput>().gameObject.transform;
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


    void OnMouseDown()
    {
        //se eu cliquei nesse objeto e estou no range, interajo
        Debug.Log("mouse down");
        // if(playerIsTouching)
        // {
        //     Interact();
        // }

        //se player está sobreposto com este objeto na tela:

        //método não é perfeito, pq só considera centro do player. Mas deve ser bom o suficiente
        //traço um raio saindo da camera, passando pelo centro do player

        RaycastHit hit;
        int layerMask = LayerMask.GetMask("Interactable");
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(Player.position);
        Ray ray = Camera.main.ScreenPointToRay(screenPoint);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask) && hit.collider.gameObject == this.gameObject) {
            //se bateu no interagível, e este interagível é este objeto, 
            //então player está sobre este objeto, e a interação acontece
            Interact();
        }



    }
}
