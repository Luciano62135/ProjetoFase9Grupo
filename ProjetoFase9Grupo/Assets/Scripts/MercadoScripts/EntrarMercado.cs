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

    private MenuDePause menuDePause;

    [SerializeField]
    PhotonView pv;

    public bool cavaleiro;
    public bool paladino;
    public bool mago;
    public bool machado;

    // Start is called before the first frame update
    void Start()
    {
        pv = GetComponent<PhotonView>();
        menuDePause = FindObjectOfType<MenuDePause>().GetComponent<MenuDePause>();

    }

    // Update is called once per frame
    void Update()
    {
        if (menuDePause.estaNoPause == true)
        {
            mercado.SetActive(false);
            entrarMercadoText.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    { 
        if (other.tag == "Player")
        {
            entrarMercadoText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E) && estaNoMercado == false)
            {
                if (!pv.IsMine)
                {
                    mercado.SetActive(false);
                    estaNoMercado = false;
                }
                else
                {
                    mercado.SetActive(true);
                    estaNoMercado = true;
                }
            }
            else if (Input.GetKeyDown(KeyCode.E) && estaNoMercado == true)
            {
                mercado.SetActive(false);
                estaNoMercado = false;
            }

            if (other.gameObject.name == "Cavaleiro") 
            {
                cavaleiro = true;
            }
            else if (other.gameObject.name == "Paladino")
            {
                paladino = true;
            
            }
            else if (other.gameObject.name == "Mago")
            {
                if (!pv.IsMine)
                {
                    mago = false;
                }
                else
                {
                    mago = true;
                }
            }
            else if (other.gameObject.name == "CaraDoMachado")
            {
                if (!pv.IsMine)
                {
                    machado = false;
                }
                else
                {
                    machado = true;
                }
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            entrarMercadoText.SetActive(false);
            mercado.SetActive(false);


            if (other.gameObject.name == "CavaleiroPhoton")
            {
                cavaleiro = false;
            }
            else if (other.gameObject.name == "PaladinoPhoton")
            {
                paladino = false;
            }
            else if (other.gameObject.name == "MagoPhoton")
            {
                mago = false;
            }
            else if (other.gameObject.name == "CaraDoMachadoPhoton")
            {
                machado = false;
            }
        }
        
    }
}
