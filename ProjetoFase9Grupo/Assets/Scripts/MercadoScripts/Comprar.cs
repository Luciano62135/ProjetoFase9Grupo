using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Comprar : MonoBehaviour
{
    
    private EntrarMercado entrouMercado;
    private PlayerHud playerHud;
    private VidaPlayer player;
    private PhotonView pv;

    //precos dos itens
    [SerializeField]
    private int precoPocao;
    [SerializeField]
    private int precoMaisVida;
    [SerializeField]
    private int precoMelhoriaArma;

    private int numeroDeCompras = 2;

    //Armas
    private EspadaCavaleiro espadaCavaleiro;
    private EspadaPaladino espadaPaladino;
    private BolaDeFogo bolaDeFogo;
    private Machado machado;

    public int numeroPesonagem;  //0 - cavaleiro, 1 - paladino, 2 - mago, 3 - caraDoMachado


    // Start is called before the first frame update
    void Start()
    {
        pv = GetComponent<PhotonView>();
        entrouMercado = GameObject.Find("ColisorMercado1").GetComponent<EntrarMercado>();
        playerHud = GameObject.Find("CanvasGeral").GetComponent<PlayerHud>();
    }

    // Update is called once per frame
    void Update()
    {
        if (entrouMercado.cavaleiro == true)
        {
            numeroPesonagem = 0;
        }
        else if (entrouMercado.paladino == true)
        {
            numeroPesonagem = 1;
        }
        else if (entrouMercado.mago == true)
        {
            numeroPesonagem = 2;
        }
        else if (entrouMercado.machado == true)
        {
            numeroPesonagem = 3;
        }
    }

    public void ComprarPocao()
    {
        if (playerHud.moedas >= precoPocao && numeroDeCompras >= 1)
        {
            playerHud.moedas -= precoPocao;
            numeroDeCompras--;
            playerHud.pocoes += 1;
        }
    }

    public void ComprarMaisVida()
    {
        if (pv.IsMine)
        {
            if (numeroPesonagem == 0 && playerHud.moedas >= precoMaisVida && numeroDeCompras >= 1)
            {
                player = GameObject.Find("Cavaleiro").GetComponent<VidaPlayer>();
                player.vidaMaxima += 10;
                playerHud.moedas -= precoMaisVida;
                numeroDeCompras--;
            }
            else if (numeroPesonagem == 1 && playerHud.moedas >= precoMaisVida && numeroDeCompras >= 1)
            {
                player = GameObject.Find("Paladino").GetComponent<VidaPlayer>();
                player.vidaMaxima += 10;
                playerHud.moedas -= precoMaisVida;
                numeroDeCompras--;

            }
            else if (numeroPesonagem == 2 && playerHud.moedas >= precoMaisVida && numeroDeCompras >= 1)
            {
                player = GameObject.Find("Mago").GetComponent<VidaPlayer>();
                player.vidaMaxima += 10;
                playerHud.moedas -= precoMaisVida;
                numeroDeCompras--;

            }
            else if (numeroPesonagem == 3 && playerHud.moedas >= precoMaisVida && numeroDeCompras >= 1)
            {
                player = GameObject.Find("CaraDoMachado").GetComponent<VidaPlayer>();
                player.vidaMaxima += 10;
                playerHud.moedas -= precoMaisVida;
                numeroDeCompras--;
            }
        }
    }

    public void ComprarMelhoriaArma()
    {
        if (pv.IsMine)
        {
            if (numeroPesonagem == 0 && playerHud.moedas >= precoMelhoriaArma && numeroDeCompras >= 1)
            {
                espadaCavaleiro = GameObject.Find("EspadaCavaleiro").GetComponent<EspadaCavaleiro>();
                espadaCavaleiro.danoMinimo += 5;
                espadaCavaleiro.danoMaximo += 5;
                playerHud.moedas -= precoMelhoriaArma;
                numeroDeCompras--;
            }
            else if (numeroPesonagem == 1 && playerHud.moedas >= precoMelhoriaArma && numeroDeCompras >= 1)
            {
                espadaPaladino = GameObject.Find("EspadaPaladino").GetComponent<EspadaPaladino>();
                espadaPaladino.danoMinimo += 5;
                espadaPaladino.danoMaximo += 5;
                playerHud.moedas -= precoMelhoriaArma;
                numeroDeCompras--;
            }
            else if (numeroPesonagem == 2 && playerHud.moedas >= precoMelhoriaArma && numeroDeCompras >= 1)
            {
                bolaDeFogo = GameObject.Find("BolaDeFogo").GetComponent<BolaDeFogo>();
                bolaDeFogo.danoMinimo += 5;
                bolaDeFogo.danoMaximo += 5;
                playerHud.moedas -= precoMelhoriaArma;
                numeroDeCompras--;
            }
            else if (numeroPesonagem == 3 && playerHud.moedas >= precoMelhoriaArma && numeroDeCompras >= 1)
            {
                machado = GameObject.Find("Machado").GetComponent<Machado>();
                machado.danoMinimo += 5;
                machado.danoMaximo += 5;
                playerHud.moedas -= precoMelhoriaArma;
                numeroDeCompras--;
            }
        }
    }
}
