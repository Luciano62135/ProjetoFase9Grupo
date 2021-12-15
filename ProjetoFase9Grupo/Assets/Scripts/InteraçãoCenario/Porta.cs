using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    public Animator anim;

    public bool estaNaPorta;

    private DialogoManager dialogoManager;

    public int numeroPorta;

    private GameObject porta, porta2;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        porta = GameObject.Find("Porta (1)");
        porta2 = GameObject.Find("Porta");
    }

    private void OnTriggerEnter(Collider other)
    {
        estaNaPorta = true;
        dialogoManager = FindObjectOfType<DialogoManager>().GetComponent<DialogoManager>();
        if (other.tag == "Player" && Input.GetKey(KeyCode.E) && dialogoManager.chave1 == true && numeroPorta == 0)
        {
            anim.SetBool("Abrir", true);
        }
        else if (other.tag == "Player" && Input.GetKey(KeyCode.E) && dialogoManager.chave2 == true && numeroPorta == 1)
        {
            anim.SetBool("Abrir", true);
            porta.SetActive(false);
        }
        else if (other.tag == "Player" && Input.GetKey(KeyCode.E) && dialogoManager.chave2 == true && numeroPorta == 2)
        {
            anim.SetBool("Abrir", true);
            porta2.SetActive(false);
        }
        else
        {
            anim.SetBool("Abrir", false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        estaNaPorta = true;
        dialogoManager = FindObjectOfType<DialogoManager>().GetComponent<DialogoManager>();
        if (other.tag == "Player" && Input.GetKey(KeyCode.E) && dialogoManager.chave1 == true && numeroPorta == 0)
        {
          
            anim.SetBool("Abrir", true);
        }
        else if (other.tag == "Player" && Input.GetKey(KeyCode.E) && dialogoManager.chave2 == true && numeroPorta == 1)
        {
            anim.SetBool("Abrir", true);
            porta.SetActive(false);
        }
        else if (other.tag == "Player" && Input.GetKey(KeyCode.E) && dialogoManager.chave2 == true && numeroPorta == 2)
        {
            anim.SetBool("Abrir", true);
            porta2.SetActive(false);
        }
        else
        {
            anim.SetBool("Abrir", false);
        }
    }

    
}
