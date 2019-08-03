using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float distanceTolerance;
    private bool hidden;

    private SpriteRenderer sprite;

    private Vector3 desiredPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        desiredPosition = transform.position;
        sprite = GetComponent<SpriteRenderer>();
        hidden = false;
    }

    public void SetHidden(bool b)
    {
        hidden = b;
        sprite.enabled = !hidden;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, desiredPosition) >= distanceTolerance)
        {
            transform.position = Vector3.MoveTowards(transform.position, desiredPosition, movementSpeed * Time.deltaTime);
        }
        
    }

    public void SetDesiredPosition(Vector3 pos)
    {
        //se player está escondido, bloqueia movimento
        if(hidden) return;

        desiredPosition = pos;
    }
}
