using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class EspadaCavaleiro : MonoBehaviour
{
    CavaleiroScript cavaleiro;
    private float dano;

    public bool podeAtacar;

    public float danoMinimo, danoMaximo;

    PhotonView pv;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //pv.RPC("OnTriggerEnter", RpcTarget.All);
        dano = Random.RandomRange(danoMinimo, danoMaximo);
    }

    //[PunRPC]
    private void OnTriggerEnter(Collider other)
    {
        cavaleiro = GameObject.FindGameObjectWithTag("Player").GetComponent<CavaleiroScript>();

        if (other.tag == "InimigoEsqueleto" && cavaleiro.estaAtacando == true)
        {
            FindObjectOfType<Audio__Manager>().Play("DanoNoEsqueleto");
            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano);
        }
        else if (other.tag == "InimigoEsqueleto" && cavaleiro.ataqueEspecial == true)
        {
            FindObjectOfType<Audio__Manager>().Play("DanoNoEsqueleto");
            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano * 2);
        }

        if (other.tag == "InimigoGuarda" && cavaleiro.estaAtacando == true)
        {
            FindObjectOfType<Audio__Manager>().Play("DanoGuarda");
            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano);
        }
        else if (other.tag == "InimigoGuarda" && cavaleiro.ataqueEspecial == true)
        {
            FindObjectOfType<Audio__Manager>().Play("DanoGuarda");
            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano * 2);
        }

        if (other.tag == "Boss" && cavaleiro.estaAtacando == true && podeAtacar == false)
        {
            FindObjectOfType<Audio__Manager>().Play("DanoBoss");
            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano);
            podeAtacar = true;
            Invoke(nameof(delay), 1);
        }
        else if (other.tag == "Boss" && cavaleiro.ataqueEspecial == true && podeAtacar == false)
        {
            FindObjectOfType<Audio__Manager>().Play("DanoBoss");
            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano * 2);
            podeAtacar = true;
            Invoke(nameof(delay), 1);
        }
    }

    public void delay()
    {
        podeAtacar = false;
    }
}
