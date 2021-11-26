using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Conectar : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject painelLogin, paineSala;
    [SerializeField]
    private InputField nomeJogador, nomeSala;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Login()
    {
        PhotonNetwork.NickName = nomeJogador.text;
        PhotonNetwork.ConnectUsingSettings();
        painelLogin.SetActive(false);
        paineSala.SetActive(true);
    }

    public void CriarSala()
    {
        PhotonNetwork.CreateRoom(nomeSala.text, new RoomOptions(), TypedLobby.Default);
        Invoke(nameof(TempoParaEntrarSala), 3);
    }

    public void TempoParaEntrarSala()
    {
        PhotonNetwork.LoadLevel("SampleScene");
        
    }

    public void EntrarSala()
    {
        PhotonNetwork.JoinRoom(nomeSala.text);
        Invoke(nameof(TempoParaEntrarSala), 3);
    }

    public void EntrarEmSalaAleatoria()
    {
        PhotonNetwork.JoinRandomRoom();
        PhotonNetwork.LoadLevel("SampleScene");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Conectado!!");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Lobby!!");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Conexão Perdida");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Não entrou em nenhuma sala");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Entrou em uma sala");
        print(PhotonNetwork.CurrentRoom.Name);
        print(PhotonNetwork.CurrentRoom.PlayerCount);
        print(PhotonNetwork.NickName);
    }
}
