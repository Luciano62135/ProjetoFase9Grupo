using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InimigoEsqueleto : MonoBehaviour
{
    //Componentes
    public Animator esqueletoAnim;
    public NavMeshAgent agent;

    //Layers
    public LayerMask OqueEChao, OqueEPlayer;

    //ataque
    public float tempoEntreOAtaque;
    public bool prontoProAtaque;

    //estados (no caso oque vai ativar os estados)
    public float alcanceDeVisao, AlcanceDoAtaque;
    public bool jogadorNaAreaDeVisao, jogadorNaAreaDeAtaque;

    //teste para pegar a posicao do player
    public Vector3 posicaoPlayer;

    public void Start()
    {
        esqueletoAnim = GetComponent<Animator>();
    }

    public void Update()
    {
        posicaoPlayer = GameObject.FindGameObjectWithTag("Player").transform.position;

        //verifique a visão e o alcance de ataque
        jogadorNaAreaDeVisao = Physics.CheckSphere(transform.position, alcanceDeVisao, OqueEPlayer);
        jogadorNaAreaDeAtaque = Physics.CheckSphere(transform.position, AlcanceDoAtaque, OqueEPlayer);

        if (jogadorNaAreaDeVisao && !jogadorNaAreaDeAtaque)
        {
            ChasePlayer();
            esqueletoAnim.SetBool("Andando", true);
        }
        else
        {
            esqueletoAnim.SetBool("Andando", false);
        }
        if (jogadorNaAreaDeAtaque && jogadorNaAreaDeVisao)
        {
            AtaqueOPlayer();
            esqueletoAnim.SetBool("Atacando", true);
            esqueletoAnim.SetBool("Andando", false);
        }
        else
        {
            esqueletoAnim.SetBool("Atacando", false);
        }

    }

    public void ChasePlayer()
    {
        agent.SetDestination(posicaoPlayer);

    }

    public void AtaqueOPlayer()
    {

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AlcanceDoAtaque);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, alcanceDeVisao);

    }


}
