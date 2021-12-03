using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VoltarMenu : MonoBehaviour
{
    public GameObject login, server;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void voltarMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void voltarLogin()
    {
        login.SetActive(true);
        server.SetActive(false);
    }
}
