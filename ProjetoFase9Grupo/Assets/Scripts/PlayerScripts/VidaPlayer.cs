using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class VidaPlayer : PlayersManager
{
    private PlayerHud playerHud;

    PhotonView pv;

    private MachadoScript player;

    private EscolhaDePersonagens escolhaPersonagem;

    // Start is called before the first frame update
    void Start()
    {
        pv = GetComponent<PhotonView>();
        barraDeVida = GameObject.Find("VidaPlayer").GetComponent<BarraDeVida>();
        vidaAtual = vidaMaxima;
        barraDeVida.SetarVidaMaxima(vidaMaxima);
        playerHud = GameObject.Find("CanvasGeral").GetComponent<PlayerHud>();
    }

    // Update is called once per frame
    void Update()
    {
        escolhaPersonagem = FindObjectOfType<EscolhaDePersonagens>().GetComponent<EscolhaDePersonagens>();
        barraDeVida.SetarVida(vidaAtual);

        if (Input.GetButtonDown("UsarCura") && playerHud.pocoes > 0)
        {
            playerHud.pocoes--;
            vidaAtual += playerHud.cura;
            if (vidaAtual > vidaMaxima)
            {
                vidaAtual = vidaMaxima;
            }
        }
    }

    public void TakeDamage(float dano)
    {
        vidaAtual -= dano;
        barraDeVida.SetarVida(vidaAtual);
        FindObjectOfType<Audio__Manager>().Play("DanoHumano");
        if (vidaAtual <= 0f)
        {
            if (escolhaPersonagem.numeroPersonagem == 1)
            {
                PaladinoScript paladino = FindObjectOfType<PaladinoScript>();
                paladino.estaMorto = true;
            }
            else if (escolhaPersonagem.numeroPersonagem == 2)
            {
                CavaleiroScript cavaleiro = FindObjectOfType<CavaleiroScript>();
                cavaleiro.estaMorto = true;
            }
            else if (escolhaPersonagem.numeroPersonagem == 3)
            {
                MagoScript mago = FindObjectOfType<MagoScript>();
                mago.estaMorto = true;
            }
            else if (escolhaPersonagem.numeroPersonagem == 4)
            {
                MachadoScript machado = FindObjectOfType<MachadoScript>();
                machado.estaMorto = true;
            }
        }
    }
}
