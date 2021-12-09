using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoColisão : MonoBehaviour
{
    public bool dialoEstaAberto;
    public bool dialogoCompleto;

    public int NumeroColisão;

    public Dialogo dialogo; 

    public void ColisãoDialogo()
    {
        FindObjectOfType<DialogoManager>().StartDialogo(dialogo);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && dialogoCompleto == false && dialoEstaAberto == false)
        {
            dialoEstaAberto = true;
            FindObjectOfType<DialogoManager>().dialogo.SetActive(true);
            FindObjectOfType<DialogoManager>().StartDialogo(dialogo);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && dialoEstaAberto == true)
        {
            dialoEstaAberto = false;
            FindObjectOfType<DialogoManager>().SairDialogo();
        }
    }
}
