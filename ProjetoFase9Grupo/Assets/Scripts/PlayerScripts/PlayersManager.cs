using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{ 
    private Vector3 BotaoDeMovimento;
    private Vector3 moveVelocity;

    public bool estaAtacando = false;
    //[SerializeField]
    //private PhotonView pv;

    public float vidaAtual;
    public float vidaMaxima = 100;
    public BarraDeVida barraDeVida;

    public void Start()
    {
        
    }

}
