using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScriptInimigoPai : MonoBehaviour
{
    //Componentes
    public Animator esqueletoAnim;
    public NavMeshAgent agent;

    //Layers
    public LayerMask OqueEChao, OqueEPlayer;

    //ataque
    public float tempoEntreOAtaque;
    public int numeroDoAtaque;

    //estados (no caso oque vai ativar os estados)
    public float alcanceDeVisao, AlcanceDoAtaque;

    //teste para pegar a posicao do player
    public Vector3 posicaoPlayer;

}
