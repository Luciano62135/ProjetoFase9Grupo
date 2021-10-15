using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaPlayer : PlayersManager
{

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
            Destroy(this.gameObject);
        }
    }
}
