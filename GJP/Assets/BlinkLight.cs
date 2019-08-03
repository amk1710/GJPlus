using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkLight : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Blink(bool blink)
    {
        animator.SetBool("Blink", blink);
    }


}
