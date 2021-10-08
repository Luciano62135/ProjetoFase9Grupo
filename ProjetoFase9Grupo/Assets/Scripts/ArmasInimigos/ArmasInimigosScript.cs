using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmasInimigosScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {

        InimigoEsqueleto esqueleto = GetComponent<InimigoEsqueleto>();
        PlayersManager players = GetComponent<PlayersManager>();

        /*if (other.tag == "Player" && esqueleto.estaAtacando == true)
        {
            players.TakeDamage(esqueleto.dano);
            esqueleto.prontoProAtaque = true;
            esqueleto.Invoke(nameof(esqueleto.ResetaOAtaque), esqueleto.tempoEntreOAtaque);
        }*/
    }
}
