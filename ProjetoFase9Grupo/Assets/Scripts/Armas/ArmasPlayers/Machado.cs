using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class Machado : MonoBehaviour
{
    MachadoScript caraDoMachado;

    public float dano;

    public float danoMinimo, danoMaximo;

    public bool podeAtacar;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        dano = Random.RandomRange(danoMinimo, danoMaximo);

    }

    private void OnTriggerEnter(Collider other)
    {
        caraDoMachado = GameObject.Find("CaraDoMachado").GetComponent<MachadoScript>();

        if (other.gameObject.tag == "InimigoEsqueleto" && caraDoMachado.estaAtacando == true && podeAtacar == false)
        {
            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano);
            podeAtacar = true;
            Invoke(nameof(delay), 1.5f);
        }
        else if (other.tag == "InimigoEsqueleto" && caraDoMachado.ataqueEspecial == true && podeAtacar == false)
        {
            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano * 2f);
            podeAtacar = true;
            Invoke(nameof(delay), 1.5f);
        }

        if (other.tag == "InimigoGuarda" && caraDoMachado.estaAtacando == true && podeAtacar == false)
        {
            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano);
            podeAtacar = true;
            Invoke(nameof(delay), 1.5f);
        }
        else if (other.tag == "InimigoGuarda" && caraDoMachado.ataqueEspecial == true && podeAtacar == false)
        {
            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano * 2);
            podeAtacar = true;
            Invoke(nameof(delay), 1.5f);
        }

        if (other.tag == "Boss" && caraDoMachado.estaAtacando == true && podeAtacar == false)
        {
            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano);
            podeAtacar = true;
            Invoke(nameof(delay), 1.5f);
        }
        else if (other.tag == "Boss" && caraDoMachado.ataqueEspecial == true && podeAtacar == false)
        {
            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano * 2);
            podeAtacar = true;
            Invoke(nameof(delay), 1.5f);
        }
    }

    public void delay()
    {
        podeAtacar = false;
    }
}
