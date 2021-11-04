using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class EscolhaDePersonagens : MonoBehaviourPunCallbacks
{
    public int numeroPersonagem = 0;

    public int depthCamera = 1;

    //objetos que serão desativados ou ativados ao escolher o personagem.
    public GameObject escolhaHUD;
    public GameObject playerHud;
    public Camera mainCamera;
    //Personagens
    public GameObject paladino;
    public GameObject cavaleiro;
    public GameObject mago;
    public GameObject machado;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Comecar()
    {
        switch (numeroPersonagem)
        {
            case 0:

                numeroPersonagem = Random.RandomRange(1, 4);
                Comecar();
                break;
            case 1:
                PhotonNetwork.Instantiate(paladino.name, new Vector3(1.5f, 1, -1.5f), Quaternion.Euler(0, 0, 0), 0);
                playerHud.SetActive(true);
                escolhaHUD.SetActive(false);
                Invoke(nameof(TempoPraTrocarDeCamera), 1);
                break;
            case 2:
                PhotonNetwork.Instantiate(cavaleiro.name, new Vector3(1.5f, 1, -1.5f), Quaternion.Euler(0,0,0), 0);
                playerHud.SetActive(true);
                escolhaHUD.SetActive(false);
                Invoke(nameof(TempoPraTrocarDeCamera), 1);
                break;
            case 3:
                PhotonNetwork.Instantiate(mago.name, new Vector3(1.5f, 1, -1.5f), Quaternion.Euler(0,0,0), 0);
                playerHud.SetActive(true);
                escolhaHUD.SetActive(false);
                Invoke(nameof(TempoPraTrocarDeCamera), 1);
                break;
            case 4:
                PhotonNetwork.Instantiate(machado.name, new Vector3(1.5f, 1, -1.5f), Quaternion.Euler(0,0,0), 0);
                playerHud.SetActive(true);
                escolhaHUD.SetActive(false);
                Invoke(nameof(TempoPraTrocarDeCamera), 1);
                break;
        }
    }

    public void EscolherPaladino()
    {
        numeroPersonagem = 1;
    }

    public void EscolherCavaleiro()
    {
        numeroPersonagem = 2;
    }

    public void EscolherMago()
    {
        numeroPersonagem = 3;
    }

    public void EscolherMachado()
    {
        numeroPersonagem = 4;
    }

    public void TempoPraTrocarDeCamera()
    {
        depthCamera = -1;
        mainCamera.depth = Camera.main.depth - 2;
    }
}
