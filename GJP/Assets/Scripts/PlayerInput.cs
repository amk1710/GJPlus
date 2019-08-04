using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{
    // Start is called before the first frame update

    private PlayerMovement playerMovement;

    public Camera ortographicCamera;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //botão esquerdo do mouse determina posição desejada
        if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) //se apertei o botão && o mouse não está sobre algum elemento da UI
        {
            //traço um raio até o plano inclinado, e esse plano determina a posição que eu quero ir
            //Debug.Log(Input.mousePosition);
            //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            
            //traça um raio do centro da camera até o plano inclinado
            // RaycastHit hit;
            // Vector3 direction = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f) - Camera.main.transform.position;
            // bool b = Physics.Raycast(Camera.main.transform.position, direction, out hit, Mathf.Infinity);
            // Debug.DrawRay(Camera.main.transform.position, direction, Color.white, 1.0f);
            // if(b)
            // {
            //     Debug.Log(hit.distance);
            // }
            // else
            // {
            //     Debug.Log("not");
            // }

            // RaycastHit hit;
            // int layerMask = LayerMask.GetMask("PlanoInclinado");
            // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)) {
            //     Vector3 desiredPosition = hit.point;
            //     //desiredPosition.z = Mathf.Min(desiredPosition.z, -7.23f);
            //     //desiredPosition.z = Mathf.Clamp(desiredPosition.z, 0.0f, 20.0f);
            //     Debug.Log(desiredPosition);
            //     Debug.DrawRay(Camera.main.ScreenToWorldPoint(Input.mousePosition), desiredPosition, Color.red, 1.0f);
            //     playerMovement.SetDesiredPosition(desiredPosition);
            // }
            
            playerMovement.SetDesiredPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    //https://answers.unity.com/questions/566519/camerascreentoworldpoint-in-perspective.html
    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z) 
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }

}

