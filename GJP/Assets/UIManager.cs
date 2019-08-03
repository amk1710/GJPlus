using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject bestiario;
    public Button NextButton;
    public Button PreviousButton;
    public Button bestiarioButton;
    public Text loseText;
    public Text winText;
    public Button retryButton;

    private bool alreadyWon;
    private bool alreadyLost;

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

        //seta estado inicial certo
        bestiario.SetActive(false);
        
        NextButton.gameObject.SetActive(true);
        PreviousButton.gameObject.SetActive(true);
        bestiarioButton.gameObject.SetActive(true);
        
        loseText.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);


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

    public void LoseGame(int monsterId)
    {
        if(alreadyWon) return;
        alreadyLost = true;
        Debug.Log("Player loses");

        //abre bestiário na página do bixo
        bestiario.SetActive(true);
        bestas[currentBesta].SetActive(false);
        currentBesta = monsterId;
        bestas[currentBesta].SetActive(true);

        //desliga botões inadequados à situação
        NextButton.gameObject.SetActive(false);
        PreviousButton.gameObject.SetActive(false);
        bestiarioButton.gameObject.SetActive(false);
        

        //liga titulo "você perdeu" e texto explicativo
        loseText.gameObject.SetActive(true);

        //liga botão para tentar de novo
        retryButton.gameObject.SetActive(true);

    }

    public void WinGame()
    {
        if(alreadyLost) return;
        alreadyWon = true;
        Debug.Log("Player loses");

        //desliga botões inadequados à situação
        NextButton.gameObject.SetActive(false);
        PreviousButton.gameObject.SetActive(false);
        bestiarioButton.gameObject.SetActive(false);
        

        //liga titulo "você ganhou" e texto explicativo
        winText.gameObject.SetActive(true);

        //liga botão para tentar de novo
        retryButton.gameObject.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
