using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float distanceTolerance;
    private bool hidden;

    public SpriteRenderer spriteL;
    public SpriteRenderer spriteR;
    private Animator animator;

    private Vector3 desiredPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        desiredPosition = transform.position;
        hidden = false;
        animator = GetComponent<Animator>();
    }

    public void SetHidden(bool b)
    {
        hidden = b;
        spriteL.enabled = !hidden;
        spriteR.enabled = !hidden;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, desiredPosition) >= distanceTolerance)
        {
            transform.position = Vector3.MoveTowards(transform.position, desiredPosition, movementSpeed * Time.deltaTime);
            
            //seta direção, right e left:
            if(transform.position.x > desiredPosition.x)
            {
                animator.SetBool("LookLeft", true);
            }
            else if(transform.position.x < desiredPosition.x)
            {
                animator.SetBool("LookLeft", false);
            }

            //de qualquer forma, está andando
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }

        
    }

    public void SetDesiredPosition(Vector3 pos)
    {
        //se player está escondido, bloqueia movimento
        if(hidden) return;

        desiredPosition = pos;
    }
}
