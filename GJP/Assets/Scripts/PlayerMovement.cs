using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
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
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, movementSpeed * Time.deltaTime);
    }

    public void SetDesiredPosition(Vector3 pos)
    {
        //se player está escondido, bloqueia movimento
        if(hidden) return;

        pos.z = 0.0f;
        desiredPosition = pos;
    }
}
