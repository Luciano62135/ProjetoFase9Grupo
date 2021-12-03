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

    public bool cavaleiro;
    public bool paladino;
    public bool mago;
    public bool machado;

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

            if (other.gameObject.name == "CavaleiroPhoton") 
            {
                cavaleiro = true;
            }
            else if (other.gameObject.name == "PaladinoPhoton")
            {
                paladino = true;
            }
            else if (other.gameObject.name == "")
            {
                mago = true;
            }
            else if (other.gameObject.name == "")
            {
                machado = true;
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            entrarMercadoText.SetActive(false);
            mercado.SetActive(false);


            if (other.gameObject.name == "ybot")
            {
                cavaleiro = false;
            }
            else if (other.gameObject.name == "ybot")
            {
                paladino = false;
            }
            else if (other.gameObject.name == "ybot")
            {
                mago = false;
            }
            else if (other.gameObject.name == "ybot")
            {
                machado = false;
            }
        }
        
    }
}
