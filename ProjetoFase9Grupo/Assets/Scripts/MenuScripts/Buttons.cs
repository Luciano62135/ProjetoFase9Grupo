using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class Buttons : MonoBehaviour
{
    [SerializeField]
    private GameObject painelLogin, menu, settings;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void MultiplayerButton()
    {
        FindObjectOfType<Audio__Manager>().Play("Selecionar");
        painelLogin.SetActive(true);
        menu.SetActive(false);
    }

    public void PlayButton()
    {
        FindObjectOfType<Audio__Manager>().Play("Selecionar");
        SceneManager.LoadScene("SampleScene");
    }

    public void CreditosButton()
    {
        FindObjectOfType<Audio__Manager>().Play("Selecionar");
        SceneManager.LoadScene("Creditos");
    }

    public void MenuButton()
    {
        FindObjectOfType<Audio__Manager>().Play("Selecionar");
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void QuitButton()
    {
        FindObjectOfType<Audio__Manager>().Play("Selecionar");
        Application.Quit();
        
    }

    public void Settings()
    {
        FindObjectOfType<Audio__Manager>().Play("Selecionar");
        menu.SetActive(false);
        settings.SetActive(true);
    }

    public void VoltarMenu()
    {
        FindObjectOfType<Audio__Manager>().Play("Selecionar");
        menu.SetActive(true);
        settings.SetActive(false);
    }

    public void Entrar()
    {
        PhotonNetwork.LoadLevel("SampleScene");
    }
}
