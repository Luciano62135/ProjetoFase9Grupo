using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField]
    private GameObject painelLogin, menu;

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
}
