using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InimigoEsqueleto))]
public class ArmasInimigosScript : MonoBehaviour
{
    InimigoEsqueleto esqueleto;
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
        esqueleto = GameObject.FindGameObjectWithTag("Inimigo").GetComponent<InimigoEsqueleto>();

        if (other.tag == "Player" && esqueleto.estaAtacando == true)
        {
            other.gameObject.GetComponent<VidaPlayer>().TakeDamage(dano);
        }
    }
}
