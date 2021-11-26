using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class EntrarMercado : MonoBehaviour
{
    public GameObject mercado;
    public GameObject entrarMercadoText;
    public bool estaNoMercado;

    PhotonView pv;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (pv.IsMine)
        {
            if (other.tag == "Player")
            {
                entrarMercadoText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E) && estaNoMercado == false)
                {
                    mercado.SetActive(true);
                    estaNoMercado = true;
                }
                else if (Input.GetKeyDown(KeyCode.E) && estaNoMercado == true)
                {
                    mercado.SetActive(false);
                    estaNoMercado = false;
                }
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (pv.IsMine)
        {
            if (other.tag == "Player")
            {
                entrarMercadoText.SetActive(false);
                mercado.SetActive(false);
            }
        }
    }
}
