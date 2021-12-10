using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmasInimigosScript : MonoBehaviour
{
    InimigoEsqueleto esqueleto;
    public float dano;

    public float danoMinimo, danoMaximo;

    public bool podeDarDano;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        dano = Random.RandomRange(danoMinimo, danoMaximo);
    }

    private void OnTriggerExit(Collider other)
    {
        VidaPlayer vidaPlayer = GetComponent<VidaPlayer>();
        esqueleto = GetComponentInParent<InimigoEsqueleto>();

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
