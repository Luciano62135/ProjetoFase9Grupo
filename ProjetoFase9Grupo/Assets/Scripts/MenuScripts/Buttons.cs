using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void CreditosButton()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
