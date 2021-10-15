using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmasPlayersScript : MonoBehaviour
{
    PlayersManager players;
    public bool estaAtacando = false;
    public float dano;

    // Start is called before the first frame update
    void Start()
    {
        players = GetComponent<PlayersManager>();
    }

    // Update is called once per frame
    void Update()
    {
        dano = Random.RandomRange(10, 20);
    }

    private void OnTriggerEnter(Collider other)
    {
        InimigoEsqueleto esqueleto = transform.GetComponent<InimigoEsqueleto>();
        VidaInimigoScript vidainimigo = GetComponent<VidaInimigoScript>();

        if (other.gameObject.tag == "Inimigo" && players.estaAtacando == true)
        {
            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano);
        }
    }
}
