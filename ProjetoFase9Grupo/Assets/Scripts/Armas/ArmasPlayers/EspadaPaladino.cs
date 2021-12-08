using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspadaPaladino : MonoBehaviour
{
    PaladinoScript paladino;

    private float dano;

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
        paladino = GameObject.FindGameObjectWithTag("Player").GetComponent<PaladinoScript>();

        if (other.tag == "InimigoEsqueleto" && paladino.estaAtacando == true)
        {
            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano);
        }
        else if (other.tag == "InimigoEsqueleto" && paladino.ataqueEspecial == true)
        {
            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano * 2);
        }

        if (other.tag == "InimigoGuarda" && paladino.estaAtacando == true)
        {
            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano);
        }
        else if (other.tag == "InimigoGuarda" && paladino.ataqueEspecial == true)
        {
            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano * 2);
        }
    }
}
