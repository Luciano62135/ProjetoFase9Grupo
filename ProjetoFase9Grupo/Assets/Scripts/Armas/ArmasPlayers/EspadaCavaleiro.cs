using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspadaCavaleiro : MonoBehaviour
{
    CavaleiroScript cavaleiro;
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
        cavaleiro = GameObject.FindGameObjectWithTag("Player").GetComponent<CavaleiroScript>();

        if (other.tag == "InimigoEsqueleto" && cavaleiro.estaAtacando == true)
        {
            FindObjectOfType<Audio__Manager>().Play("AtaqueNoEsqueleto");
            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano);
        }
        else if (other.tag == "InimigoEsqueleto" && cavaleiro.ataqueEspecial == true)
        {
            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano * 2);
        }

        if (other.tag == "InimigoGuarda" && cavaleiro.estaAtacando == true)
        {
            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano);
        }
        else if (other.tag == "InimigoGuarda" && cavaleiro.ataqueEspecial == true)
        {
            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano * 2);
        }
    }
}
