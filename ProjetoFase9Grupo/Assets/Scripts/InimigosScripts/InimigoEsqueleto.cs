using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InimigoEsqueleto : ScriptInimigoPai
{
    public bool estaAtacando = false;
    public void Start()
    {
        esqueletoAnim = GetComponent<Animator>();
    }

    public void Update()
    {
        FaceTarget();
        numeroDoAtaque = Random.RandomRange(1, 2);
        
        posicaoPlayer = GameObject.FindGameObjectWithTag("Player").transform.position;
        

        float distance = Vector3.Distance(posicaoPlayer, transform.position);

        if (distance <= alcanceDeVisao && estaAtacando == false)
        {
            agent.SetDestination(posicaoPlayer);
            agent.stoppingDistance = 2;
            esqueletoAnim.SetBool("Andando", true);
            FaceTarget();

            if (distance <= agent.stoppingDistance)
            {
                if (numeroDoAtaque == 1)
                {
                    esqueletoAnim.SetBool("Andando", false);
                    esqueletoAnim.SetBool("Atacando", true);
                    estaAtacando = true;
                    agent.isStopped = true;
                    Invoke(nameof(TempoEntreOAtaque), tempoEntreOAtaque);
                }
                if (numeroDoAtaque == 2)
                {
                    esqueletoAnim.SetBool("Andando", false);
                    esqueletoAnim.SetBool("Atacando2", true);
                    agent.isStopped = true;
                    estaAtacando = true;
                    Invoke(nameof(TempoEntreOAtaque), tempoEntreOAtaque);
                }
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
