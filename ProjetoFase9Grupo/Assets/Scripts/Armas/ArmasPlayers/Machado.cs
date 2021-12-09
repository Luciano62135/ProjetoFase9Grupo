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

        if (other.gameObject.tag == "InimigoEsqueleto" && caraDoMachado.estaAtacando == true)
        {

            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano);
        }
        else if (other.tag == "InimigoEsqueleto" && caraDoMachado.ataqueEspecial == true)
        {
            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano * 2);
        }

        if (other.tag == "InimigoGuarda" && caraDoMachado.estaAtacando == true)
        {
            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano);
        }
        else if (other.tag == "InimigoGuarda" && caraDoMachado.ataqueEspecial == true)
        {
            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano * 2);
        }
    }
}
