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

    public float interactionDistance = 3.0f;
    public float timeInterval_autoInteraction = 2.0f;

    private bool TryToInteract;
    
    // Start is called before the first frame update
    void Start()
    {
        playerIsTouching = false;
        condition = GetComponent<BaseCondition>();
        Player = GameObject.FindObjectOfType<PlayerInput>().gameObject.transform;

        TryToInteract = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(playerIsTouching);
        if(TryToInteract && Vector3.Distance(transform.position, Player.position) < interactionDistance)
        {
            Interact();
            TryToInteract = false;
        }
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

        // RaycastHit hit;
        // int layerMask = LayerMask.GetMask("Interactable");
        // Vector3 screenPoint = Camera.main.WorldToScreenPoint(Player.position);
        // Ray ray = Camera.main.ScreenPointToRay(screenPoint);
        // if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask) && hit.collider.gameObject == this.gameObject) {
        //     //se bateu no interagível, e este interagível é este objeto, 
        //     //então player está sobre este objeto, e a interação acontece
        //     Interact();
        // }
        // else
        // //se o player não está sobreposto
        // {

        // }

        //se está próximo o suficiente, interage
        Debug.LogWarning(Vector3.Distance(transform.position, Player.position));
        if(Vector3.Distance(transform.position, Player.position) < interactionDistance)
        {
            Interact();
        }
        //senão, desloca player até o objeto e seta flag para interagir quando entrar no range
        else if(!TryToInteract)
        {
            StartCoroutine(TryToInteract_Coroutine(timeInterval_autoInteraction));
        }

    }

    IEnumerator TryToInteract_Coroutine(float time)
    {
        TryToInteract = true;
        Debug.LogWarning("set true");
        yield return new WaitForSecondsRealtime(time);
        Debug.LogWarning("set false");
        TryToInteract = false;
        yield break;
    }
}
