using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class EscolhaDePersonagens : MonoBehaviour
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
        FindObjectOfType<Audio__Manager>().Play("Coletar");
        switch (numeroPersonagem)
        {
            case 0:

                numeroPersonagem = Random.RandomRange(1, 4);
                Comecar();
                break;
            case 1:
                Instantiate(paladino, new Vector3(-4, 0, 27), Quaternion.Euler(0, 0, 0));
                playerHud.SetActive(true);
                escolhaHUD.SetActive(false);
                Invoke(nameof(TempoPraTrocarDeCamera), 1);
                break;
            case 2:
                Instantiate(cavaleiro, new Vector3(-4, 0, 33), Quaternion.Euler(0,0,0));
                playerHud.SetActive(true);
                escolhaHUD.SetActive(false);
                Invoke(nameof(TempoPraTrocarDeCamera), 1);
                break;
            case 3:
                Instantiate(mago, new Vector3(14f, 0, 62), Quaternion.Euler(0,0,0));
                playerHud.SetActive(true);
                escolhaHUD.SetActive(false);
                Invoke(nameof(TempoPraTrocarDeCamera), 1);
                break;
            case 4:
                Instantiate(machado, new Vector3(8.5f, 0, 27f), Quaternion.Euler(0,0,0));
                playerHud.SetActive(true);
                escolhaHUD.SetActive(false);
                Invoke(nameof(TempoPraTrocarDeCamera), 1);
                break;
        }
    }

    public void EscolherPaladino()
    {
        numeroPersonagem = 1;
        FindObjectOfType<Audio__Manager>().Play("Coletar");
    }

    public void EscolherCavaleiro()
    {
        numeroPersonagem = 2;
        FindObjectOfType<Audio__Manager>().Play("Coletar");
    }

    public void EscolherMago()
    {
        numeroPersonagem = 3;
        FindObjectOfType<Audio__Manager>().Play("Coletar");
    }

    public void EscolherMachado()
    {
        numeroPersonagem = 4;
        FindObjectOfType<Audio__Manager>().Play("Coletar");
    }

    public void TempoPraTrocarDeCamera()
    {
        depthCamera = -1;
        mainCamera.depth = Camera.main.depth - 2;
        mainCamera.enabled = false;
    }
}
