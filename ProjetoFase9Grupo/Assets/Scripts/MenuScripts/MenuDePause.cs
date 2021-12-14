using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDePause : MonoBehaviour
{
    public GameObject menuDePause, playerHud, configuracoes;
    public bool estaNoPause = false;

    private EscolhaDePersonagens escolhaPersonagem;


    // Start is called before the first frame update
    void Start()
    {
        estaNoPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        escolhaPersonagem = FindObjectOfType<EscolhaDePersonagens>().GetComponent<EscolhaDePersonagens>();
        if (escolhaPersonagem.estaEscolhendo == false)
        {
            if (Input.GetKeyUp(KeyCode.P) && estaNoPause == false)
            {
                playerHud.SetActive(false);
                menuDePause.SetActive(true);
                estaNoPause = true;
            }
            else if (Input.GetKeyUp(KeyCode.P) && estaNoPause == true)
            {
                playerHud.SetActive(true);
                menuDePause.SetActive(false);
                configuracoes.SetActive(false);
                estaNoPause = false;
            }
        }
    }

    public void VoltarJogo()
    {
        playerHud.SetActive(true);
        menuDePause.SetActive(false);
    }

    public void Configuracao()
    {
        menuDePause.SetActive(false);
        configuracoes.SetActive(true);
    }

    public void VoltarMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void SairDoJogo()
    {
        Application.Quit();
    }
}
