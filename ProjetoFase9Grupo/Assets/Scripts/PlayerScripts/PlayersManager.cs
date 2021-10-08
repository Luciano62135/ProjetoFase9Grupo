using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{ 
    private Vector3 BotaoDeMovimento;
    private Vector3 moveVelocity;

    public float vidaAtual;
    public float vidaMaxima = 100;

    public bool estaAtacando = false;
    //[SerializeField]
    //private PhotonView pv;
    public BarraDeVida barraDeVida;
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
