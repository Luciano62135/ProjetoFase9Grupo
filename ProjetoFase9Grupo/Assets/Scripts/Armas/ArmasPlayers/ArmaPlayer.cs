using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CavaleiroScript))]
public class ArmaPlayer : MonoBehaviour
{
    CavaleiroScript cavaleiro;
    public float dano;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        dano = Random.RandomRange(7, 14);
    }

    private void OnTriggerEnter(Collider other)
    {
        VidaPlayer vidaPlayer = GetComponent<VidaPlayer>();
        cavaleiro = GameObject.FindGameObjectWithTag("Player").GetComponent<CavaleiroScript>();

        if (other.tag == "Inimigo" && cavaleiro.estaAtacando == true)
        {
            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano);
        }
    }
}
