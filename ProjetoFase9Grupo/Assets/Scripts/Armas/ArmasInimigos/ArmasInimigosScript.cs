using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InimigoEsqueleto))]
public class ArmasInimigosScript : MonoBehaviour
{
    InimigoEsqueleto esqueleto;
    public float dano;

    public bool podeDarDano;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        dano = Random.RandomRange(7, 14);
    }

    private void OnTriggerExit(Collider other)
    {
        VidaPlayer vidaPlayer = GetComponent<VidaPlayer>();
        esqueleto = GameObject.FindGameObjectWithTag("InimigoEsqueleto").GetComponent<InimigoEsqueleto>();

        if (other.tag == "Player" && esqueleto.estaAtacando == true && podeDarDano == false)
        {
            other.gameObject.GetComponent<VidaPlayer>().TakeDamage(dano);
            podeDarDano = true;
            Invoke(nameof(TempoEntreODano), 1);
        }
    }

    public void TempoEntreODano()
    {
        podeDarDano = false;
    }
}
