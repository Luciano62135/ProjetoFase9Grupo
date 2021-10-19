using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmasPlayersScript : MonoBehaviour
{
    CavaleiroScript players;
    public float dano;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        dano = Random.RandomRange(10, 20);
    }

    private void OnTriggerEnter(Collider other)
    {
        players = GameObject.FindGameObjectWithTag("Player").GetComponent<CavaleiroScript>();
        VidaInimigoScript vidainimigo = GetComponent<VidaInimigoScript>();

        if (other.gameObject.tag == "Inimigo" && players.estaAtacando == true)
        {
            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano);
        }
    }
}
