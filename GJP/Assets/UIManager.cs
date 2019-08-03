using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject bestiario;
    public Button NextButton;
    public Button PreviousButton;

    private int currentBesta;
    public List<GameObject> bestas;
    
    // Start is called before the first frame update
    void Start()
    {
        currentBesta = 0;
        foreach(GameObject besta in bestas)
        {
            besta.SetActive(false);
        }
        bestas[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentBesta == 0)
        {
            PreviousButton.interactable = false;
            NextButton.interactable = true;
        }
        else if(currentBesta == bestas.Count - 1)
        {
            PreviousButton.interactable = true;
            NextButton.interactable = false;
        }
        else
        {
            PreviousButton.interactable = true;
            NextButton.interactable = true;
        }
    }

    public void ToggleBestiario()
    {
        bestiario.SetActive(!bestiario.active);
    }

    public void NextPage()
    {
        if(currentBesta < bestas.Count - 1)
        {
            bestas[currentBesta].SetActive(false);
            currentBesta++;
            bestas[currentBesta].SetActive(true);
        }
    }

    public void PreviousPage()
    {
        if(currentBesta > 0)
        {
            bestas[currentBesta].SetActive(false);
            currentBesta--;
            bestas[currentBesta].SetActive(true);
        }
    }
}
