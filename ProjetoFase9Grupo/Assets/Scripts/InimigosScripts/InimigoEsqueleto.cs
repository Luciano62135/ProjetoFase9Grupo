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
    public bool estaAtacando = false;

    //teste para pegar a posicao do player
    public Vector3 posicaoPlayer;

    public void Start()
    {
        esqueletoAnim = GetComponent<Animator>();
    }

    public void Update()
    {
        posicaoPlayer = GameObject.FindGameObjectWithTag("Player").transform.position;

        float distance = Vector3.Distance(posicaoPlayer, transform.position);

        if (distance <= alcanceDeVisao && estaAtacando == false)
        {
            agent.SetDestination(posicaoPlayer);
            agent.stoppingDistance = 2;
            esqueletoAnim.SetBool("Andando", true);
            
            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
                esqueletoAnim.SetBool("Andando", false);
                esqueletoAnim.SetBool("Atacando", true);
                agent.isStopped = true;
                Invoke(nameof(tempoEntreOAtaque), 5);
            }
            else
            {
                esqueletoAnim.SetBool("Atacando", false);
            }
        }
        else
        {
            esqueletoAnim.SetBool("Andando", false);
        }
    }

    public void TempoEntreOAtaque()
    {
        estaAtacando = false;
        agent.isStopped = false;
    }

    void FaceTarget ()
    {
        Vector3 direction = (posicaoPlayer - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AlcanceDoAtaque);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, alcanceDeVisao);

    }


}
