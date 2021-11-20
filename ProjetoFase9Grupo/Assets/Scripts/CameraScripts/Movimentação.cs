using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Movimentação : MonoBehaviour
{
    public Transform player;

    public float speed = 0.125f;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posicaoDesejada = player.position + offset;
        Vector3 posicaoSuavizada = Vector3.Lerp(transform.position, posicaoDesejada, speed);
        transform.position = posicaoSuavizada;
    }
}

