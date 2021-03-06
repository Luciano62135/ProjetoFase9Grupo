using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class VidaInimigoScript : MonoBehaviour
{
    public float vidaAtual;
    public float vidaMaxima = 100;
    public BarraDeVida barraDeVida;
    public GameObject moedaPrata;
    public GameObject moedaCobre;
    public int chanceDaMoeda;

    public GameObject ganhou;

    InimigoBoss boss;

    PhotonView pv;

    public float danoRecebido;
    // Start is called before the first frame update
    void Start()
    {
        pv = GetComponent<PhotonView>();
        vidaAtual = vidaMaxima;
        barraDeVida.SetarVidaMaxima(vidaMaxima);
    }

    // Update is called once per frame
    void Update()
    {
        chanceDaMoeda = Random.RandomRange(1, 2);
    }

    public void ChamarTakeDamage(float dano)
    {
        pv.RPC("TakeDamage()", RpcTarget.All);
        danoRecebido = dano;
    }

    [PunRPC]
    public void TakeDamage(float dano)
    {
        vidaAtual -= dano;
        barraDeVida.SetarVida(vidaAtual);
        if (vidaAtual <= 0f)
        {
            if (this.gameObject.tag == "Boss")
            {
                boss = FindObjectOfType<InimigoBoss>().GetComponent<InimigoBoss>();
                boss.estaMorto = true;
                ganhou.SetActive(true);
            }


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
