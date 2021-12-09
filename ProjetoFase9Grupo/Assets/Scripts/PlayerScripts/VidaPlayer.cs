using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class VidaPlayer : PlayersManager
{
    private PlayerHud playerHud;

    PhotonView pv;

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

    [PunRPC]
    public void TakeDamage(float dano)
    {
        vidaAtual -= dano;
        barraDeVida.SetarVida(vidaAtual);
        FindObjectOfType<Audio__Manager>().Play("DanoHumano");
        if (vidaAtual <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
}
