using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrindoBau : MonoBehaviour
{
    private PlayerHud playerHud;
    private DialogoManager dialogoManager;
    // Start is called before the first frame update
    void Start()
    {
        playerHud = GameObject.Find("CanvasGeral").GetComponent<PlayerHud>();
    }

    // Update is called once per frame
    void Update()
    {
        dialogoManager = FindObjectOfType<DialogoManager>().GetComponent<DialogoManager>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && dialogoManager.chave3 == true && Input.GetKeyDown(KeyCode.E))
        {
            playerHud.pocoes += 2;
            dialogoManager.chave3 = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && dialogoManager.chave3 == true && Input.GetKeyDown(KeyCode.E))
        {
            playerHud.pocoes += 2;
            dialogoManager.chave3 = false;
        }
    }
}
