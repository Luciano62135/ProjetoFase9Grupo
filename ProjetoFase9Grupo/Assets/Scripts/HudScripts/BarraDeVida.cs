using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class BarraDeVida : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image preenchimentoVida;

    PhotonView pv;

    public float vidaRecebida;

    public void SetarVidaMaxima(float vida)
    {
        slider.maxValue = vida;
        slider.value = vida;

        preenchimentoVida.color = gradient.Evaluate(1f);
    }

    [PunRPC]
    public void SetarVida(float vida)
    {
        slider.value = vida;

        preenchimentoVida.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void Update()
    {

    }

    public void SetarVidaAtual(float vida)
    {
        vidaRecebida = vida;
        pv.RPC("SetarVida(float vida)", RpcTarget.All);
    }
}
