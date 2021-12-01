using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDePause : MonoBehaviour
{
    public GameObject menuDePause, playerHud, configuracoes;
    public bool estaNoPause = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P) && estaNoPause == false)
        {
            playerHud.SetActive(false);
            menuDePause.SetActive(true);
            estaNoPause = true;
        }
        if (Input.GetKey(KeyCode.P) && estaNoPause == true)
        {
            playerHud.SetActive(true);
            menuDePause.SetActive(false);
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
