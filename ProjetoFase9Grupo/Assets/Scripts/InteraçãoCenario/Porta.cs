using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    public Animator anim;

    private DialogoManager dialogoManager;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        dialogoManager = FindObjectOfType<DialogoManager>().GetComponent<DialogoManager>();
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E) && dialogoManager.chave1 == true)
        {
            anim.SetBool("Abrir", true);
        }
        else if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E) && dialogoManager.chave2 == true)
        {
            anim.SetBool("Abrir", true);
        }
        else
        {
            anim.SetBool("Abrir", false);
        }
    }
}
