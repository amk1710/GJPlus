﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Computer : MonoBehaviour
{
    public Slider chargeSlider;
    private AudioSource au;

    public float chargeSpeed;

    //de zero a 1
    float chargeStatus = 0.0f;

    public List<AudioClip> audioClips;
    public float WaitTimeSound = 1.0f;
    private HideCondition hideCondition;

    private bool alreadyWon;
    
    // Start is called before the first frame update
    void Start()
    {
        hideCondition = GetComponent<HideCondition>();
        alreadyWon = false;
        au = GetComponent<AudioSource>();

        StartCoroutine("PlaySounds");
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

        if(chargeStatus >= 1.0f && !alreadyWon)
        {
            GameObject.FindObjectOfType<UIManager>().WinGame();
            alreadyWon = true;
        }
    }

    IEnumerator PlaySounds()
    {
        while(true)
        {
            yield return new WaitForSeconds(WaitTimeSound);
            if(!au.isPlaying && audioClips.Count > 0 && hideCondition.ConditionIsMet())
            {
                au.PlayOneShot(audioClips[Random.Range(0, audioClips.Count)]);
            }
        }
    }
}
