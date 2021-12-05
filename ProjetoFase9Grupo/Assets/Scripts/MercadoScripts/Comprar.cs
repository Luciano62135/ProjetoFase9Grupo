using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Comprar : MonoBehaviour
{
    private EntrarMercado player;
    private PhotonView pv;

    private float compras = 2;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<EntrarMercado>();
        pv = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ComprarPocao()
    {
        if (pv.IsMine)
        {

        }
    }

    public void ComprarVidaMaxima()
    {

    }

    public void ComprarMelhoriaArma()
    {

    }


}
