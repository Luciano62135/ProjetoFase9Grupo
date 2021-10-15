using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmasInimigosScript : MonoBehaviour
{
    InimigoEsqueleto esqueleto;
    public bool estaAtacando = false;
    public float dano;
    // Start is called before the first frame update
    void Start()
    {
        esqueleto = GetComponent<InimigoEsqueleto>();
    }

    // Update is called once per frame
    void Update()
    {
        dano = Random.RandomRange(7, 14);
    }

    private void OnTriggerEnter(Collider other)
    {
        VidaPlayer vidaPlayer = GetComponent<VidaPlayer>();

        if (other.tag == "Player" && esqueleto.estaAtacando == true)
        {
            other.gameObject.GetComponent<VidaPlayer>().TakeDamage(dano);
        }
    }
}
