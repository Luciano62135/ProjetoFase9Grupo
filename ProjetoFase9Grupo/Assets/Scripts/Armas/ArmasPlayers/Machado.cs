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

        if (other.tag == "InimigoEsqueleto" && caraDoMachado.estaAtacando == true && podeAtacar == false)
        {
            FindObjectOfType<Audio__Manager>().Play("DanoNoEsqueleto");
            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano);
        }
        else if (other.tag == "InimigoEsqueleto" && caraDoMachado.ataqueEspecial == true && podeAtacar == false)
        {
            FindObjectOfType<Audio__Manager>().Play("DanoNoEsqueleto");
            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano * 2);
        }

        if (other.tag == "InimigoGuarda" && caraDoMachado.estaAtacando == true && podeAtacar == false)
        {
            FindObjectOfType<Audio__Manager>().Play("DanoGuarda");
            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano);
        }
        else if (other.tag == "InimigoGuarda" && caraDoMachado.ataqueEspecial == true && podeAtacar == false)
        {
            FindObjectOfType<Audio__Manager>().Play("DanoGuarda");
            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano * 2);
        }

        if (other.tag == "Boss" && caraDoMachado.estaAtacando == true && podeAtacar == false)
        {
            FindObjectOfType<Audio__Manager>().Play("DanoBoss");
            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano);
            podeAtacar = true;
            Invoke(nameof(delay), 1);
        }
        else if (other.tag == "Boss" && caraDoMachado.ataqueEspecial == true && podeAtacar == false)
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
