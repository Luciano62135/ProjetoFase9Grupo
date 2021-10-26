using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaInimigoScript : MonoBehaviour
{
    public float vidaAtual;
    public float vidaMaxima = 100;
    public BarraDeVida barraDeVida;
    public GameObject moedaPrata;
    public GameObject moedaCobre;
    public int chanceDaMoeda;

    // Start is called before the first frame update
    void Start()
    {
        vidaAtual = vidaMaxima;
        barraDeVida.SetarVidaMaxima(vidaMaxima);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float dano)
    {
        vidaAtual -= dano;
        barraDeVida.SetarVida(vidaAtual);
        if (vidaAtual <= 0f)
        {
            chanceDaMoeda = Random.RandomRange(1, 2);
            if (chanceDaMoeda == 1)
            {
                Instantiate(moedaCobre, transform.position, transform.rotation);
            }
            else if (chanceDaMoeda == 2)
            {
                Instantiate(moedaPrata, transform.position, transform.rotation);
            }
            Destroy(this.gameObject);
        }
    }
}
