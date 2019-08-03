using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public List<Monster> monsters;

    private Monster currentMonster;
    // Start is called before the first frame update
    void Start()
    {
        //no começo, todos os monstros estão desativados
        foreach(Monster monster in monsters)
        {
            monster.gameObject.SetActive(false);
        }
        //um monstro aleatório é escolhido para estar ativo
        currentMonster = monsters[Random.Range(0, monsters.Count)];
        currentMonster.gameObject.SetActive(true);
    }

    public void NextMonster()
    {
        Debug.Log("Next Monster");
        currentMonster.gameObject.SetActive(false);

        //escolhe proximo monstro e o ativa
        currentMonster = monsters[Random.Range(0, monsters.Count)];
        currentMonster.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
