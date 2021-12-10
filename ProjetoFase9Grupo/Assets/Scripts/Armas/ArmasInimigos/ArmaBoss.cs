using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaBoss : MonoBehaviour
{
    InimigoBoss inimigoBoss;
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

    private void OnTriggerEnter(Collider other)
    {
        VidaPlayer vidaPlayer = GetComponent<VidaPlayer>();
        inimigoBoss = GetComponentInParent<InimigoBoss>();

        if (other.tag == "Player" && inimigoBoss.estaAtacando == true && podeDarDano == false)
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
