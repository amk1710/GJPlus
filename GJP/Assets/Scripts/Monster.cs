using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public struct Tell{
    public float time;
    public UnityEvent tell_event;
}

[System.Serializable]
public struct MonsterCondition
{
    public BaseCondition condition;
    public bool inverse;
}

public class Monster : MonoBehaviour
{
    private MonsterManager manager;

    private Coroutine currentCoroutine;
    
    public float ActiveTime;

    public float timeStep = 0.5f;

    private int currentTell;
    public List<Tell> tells;

    public UnityEvent cleanUpEvent;

    public List<MonsterCondition> conditions;

    // Start is called before the first frame update

    void Start()
    {
        currentCoroutine = null;
        manager = GameObject.FindObjectOfType<MonsterManager>();
        currentTell = 0;
    }
    void OnEnable()
    {
        if(currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
        currentCoroutine = StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        float passedTime = 0.0f;
        while(passedTime < ActiveTime)
        {
            if(currentTell < tells.Count && tells[currentTell].time >= passedTime)
            {
                tells[currentTell].tell_event.Invoke();
                currentTell++;
            }
            Debug.Log("Monster arriving in " + (ActiveTime - passedTime).ToString() + "seconds");
            yield return new WaitForSecondsRealtime(timeStep);
            passedTime += timeStep;
        }

        //checo se as condições estão sendo atendidas
        foreach(MonsterCondition mc in conditions)
        {
            //se a condição não estiver sendo cumprida,
            //(sendo cumprida <==> condition é true e não inverte || condition é false e inverte) ==> xor
            if(!(mc.condition.ConditionIsMet() ^ mc.inverse))
            {
                cleanUpEvent.Invoke();
                GameObject.FindObjectOfType<UIManager>().LoseGame(transform.GetSiblingIndex());
                yield break;
            }
        }
        //se todas as condições estão sendo atendidas:
        
        //destrói monstro
        Debug.Log("monster was repelled");
        cleanUpEvent.Invoke();
        manager.NextMonster();
        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
