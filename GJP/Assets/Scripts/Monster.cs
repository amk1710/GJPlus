using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public List<BaseCondition> conditions;
    private MonsterManager manager;

    private Coroutine currentCoroutine;
    
    public float ActiveTime;

    // Start is called before the first frame update

    void Start()
    {
        currentCoroutine = null;
        manager = GameObject.FindObjectOfType<MonsterManager>();
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
            Debug.Log("Monster arriving in " + (ActiveTime - passedTime).ToString() + "seconds");
            yield return new WaitForSecondsRealtime(1.0f);
            passedTime += 1.0f;
        }

        //checo se as condições estão sendo atendidas
        foreach(BaseCondition condition in conditions)
        {
            if(!condition.ConditionIsMet())
            {
                Debug.Log("Player loses");
                yield break;
            }
        }
        //se todas as condições estão sendo atendidas:
        
        //destrói monstro
        Debug.Log("monster was repelled");
        manager.NextMonster();
        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
