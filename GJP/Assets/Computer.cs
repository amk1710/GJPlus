using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Computer : MonoBehaviour
{
    public Slider chargeSlider;

    public float chargeSpeed;

    //de zero a 1
    float chargeStatus = 0.0f;

    private HideCondition hideCondition;
    
    // Start is called before the first frame update
    void Start()
    {
        hideCondition = GetComponent<HideCondition>();
    }

    // Update is called once per frame
    void Update()
    {
        //se o player estiver "escondido" aqui
        if(hideCondition.ConditionIsMet())
        {
            chargeStatus += chargeSpeed * Time.deltaTime;
            chargeSlider.value = chargeStatus;
        }

        if(chargeStatus >= 1.0f)
        {
            Debug.Log("You Win!");
        }
    }
}
