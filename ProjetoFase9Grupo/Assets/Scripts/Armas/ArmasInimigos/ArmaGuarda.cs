using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaGuarda : MonoBehaviour
{
    InimigoGuarda guarda;
    public float dano = 10;

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
        guarda = GetComponentInParent<InimigoGuarda>();

        if (other.tag == "Player" && guarda.estaAtacando == true && podeDarDano == false)
        {
            other.gameObject.GetComponent<VidaPlayer>().TakeDamage(dano);
            podeDarDano = true;
            Invoke(nameof(TempoEntreODano), 1f);
        }
    }

    public void TempoEntreODano()
    {
        podeDarDano = false;
    }
}
