using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource ambient;
    public AudioClips tense;
    public AudioSource tenseAU;
    // Start is called before the first frame update
    void Start()
    {
               
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //play tense sound tem a particularidade de reduzir o volume do som ambiente a 0
    public void PlayTenseSound()
    {
        StartCoroutine("pts");
    }

    IEnumerator pts()
    {
        float vol = ambient.volume;
        ambient.volume = 0.0f;
        tense.PlayRandomClip();
        
        while(tenseAU.isPlaying)
        {
            yield return new WaitForSeconds(0.3f);
        }
        ambient.volume = vol;
    }
}