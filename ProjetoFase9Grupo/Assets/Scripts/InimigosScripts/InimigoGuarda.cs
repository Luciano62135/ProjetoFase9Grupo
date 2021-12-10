using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;
using Photon.Realtime;

public class InimigoGuarda : ScriptInimigoPai
{
    public Animator guardaAnim;
    public bool estaAtacando = false;

    PhotonView pv;
    public void Start()
    {
        guardaAnim = GetComponent<Animator>();
    }

    public void Update()
    {
        numeroDoAtaque = Random.RandomRange(1, 2);

        posicaoPlayer = GameObject.FindGameObjectWithTag("Player").transform.position;


        float distance = Vector3.Distance(posicaoPlayer, transform.position);

        if (distance <= alcanceDeVisao && estaAtacando == false)
        {
            alcanceDeVisao = 10;
            agent.SetDestination(posicaoPlayer);
            agent.stoppingDistance = 2;
            guardaAnim.SetBool("Andando", true);
            FaceTarget();

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
                if (numeroDoAtaque == 1)
                {
                    guardaAnim.SetBool("Andando", false);
                    guardaAnim.SetBool("Atacando", true);
                    estaAtacando = true;
                    agent.isStopped = true;
                    Invoke(nameof(TempoEntreOAtaque), tempoEntreOAtaque);
                }
                if (numeroDoAtaque == 2)
                {
                    guardaAnim.SetBool("Andando", false);
                    guardaAnim.SetBool("Atacando2", true);
                    agent.isStopped = true;
                    estaAtacando = true;
                    Invoke(nameof(TempoEntreOAtaque), tempoEntreOAtaque);
                }
            }
            else
            {
                guardaAnim.SetBool("Atacando", false);
            }
        }
        else
        {
            guardaAnim.SetBool("Andando", false);
            guardaAnim.SetBool("Atacando", false);
        }
    }


    public void TempoEntreOAtaque()
    {
        estaAtacando = false;
        agent.isStopped = false;
    }

    void FaceTarget()
    {
        Vector3 direction = (posicaoPlayer - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 18f);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AlcanceDoAtaque);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, alcanceDeVisao);

    }
}
