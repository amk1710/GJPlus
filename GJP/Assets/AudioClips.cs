using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClips : MonoBehaviour
{
    public bool alwaysPlay;
    public float timeInterval = 15.0f;
    public List<AudioClip> clips;
    private AudioSource au;

    void Start()
    {
        au = GetComponent<AudioSource>();
        if(alwaysPlay && clips.Count > 0)
        {
            StartCoroutine("PlayAtInterval");
        }
    }

    public void PlayRandomClip()
    {
        au.PlayOneShot(clips[Random.Range(0, clips.Count)]);
    }

    IEnumerator PlayAtInterval()
    {
        while(true)
        {
            yield return new WaitForSecondsRealtime(timeInterval);
            PlayRandomClip();
        }
    }
}
