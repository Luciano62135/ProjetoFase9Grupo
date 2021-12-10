using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoBoss : ScriptInimigoPai
{
    public Animator bossAnim;

    public bool estaAtacando = false;
    public bool podeAtacar = false;

    public float tempoTerminarAtaque;

    public void Start()
    {
        bossAnim = GetComponent<Animator>();
    }

    public void Update()
    {
        posicaoPlayer = GameObject.FindGameObjectWithTag("Player").transform.position;

        float distance = Vector3.Distance(posicaoPlayer, transform.position);

        if (distance <= alcanceDeVisao && estaAtacando == false)
        {
            FaceTarget();
            alcanceDeVisao = 10;
            agent.SetDestination(posicaoPlayer);
            agent.stoppingDistance = 2;
            bossAnim.SetBool("Andando", true);

            if (distance <= agent.stoppingDistance && podeAtacar == false)
            {
                FaceTarget();
                numeroDoAtaque = Random.RandomRange(1, 3);
                if (numeroDoAtaque == 1 && podeAtacar == false)
                {
                    bossAnim.SetBool("Andando", false);
                    bossAnim.SetBool("Atacando1", true);
                    estaAtacando = true;
                    agent.isStopped = true;
                    podeAtacar = true;
                    Invoke(nameof(TempoEntreOAtaque), tempoEntreOAtaque);
                    Invoke(nameof(EstaAtacando), tempoTerminarAtaque);
                }
                else if (numeroDoAtaque == 2 && podeAtacar == false)
                {
                    bossAnim.SetBool("Andando", false);
                    bossAnim.SetBool("Atacando2", true);
                    agent.isStopped = true;
                    estaAtacando = true;
                    podeAtacar = true;
                    Invoke(nameof(TempoEntreOAtaque), tempoEntreOAtaque);
                    Invoke(nameof(EstaAtacando), tempoTerminarAtaque);
                }
                else if (numeroDoAtaque == 3 && distance >= 3 && podeAtacar == false)
                {
                    bossAnim.SetBool("Andando", false);
                    bossAnim.SetBool("Atacando3", true);
                    agent.isStopped = true;
                    estaAtacando = true;
                    podeAtacar = true;
                    Invoke(nameof(TempoEntreOAtaque), tempoEntreOAtaque);
                    Invoke(nameof(EstaAtacando), tempoTerminarAtaque);
                }
                else
                {
                    bossAnim.SetBool("Atacando1", false);
                    bossAnim.SetBool("Atacando2", false);
                    bossAnim.SetBool("Atacando3", false);
                }
            }
            else
            {
                bossAnim.SetBool("Atacando1", false);
                bossAnim.SetBool("Atacando2", false);
                bossAnim.SetBool("Atacando3", false);
            }
        }
        else
        {
            bossAnim.SetBool("Andando", false);
            bossAnim.SetBool("Atacando", false);
        }
    }


    public void TempoEntreOAtaque()
    {
        podeAtacar = false;
    }

    public void EstaAtacando()
    {
        estaAtacando = false;
        agent.isStopped = false;
        bossAnim.SetBool("Atacando1", false);
        bossAnim.SetBool("Atacando2", false);
        bossAnim.SetBool("Atacando3", false);
        bossAnim.SetBool("Andando", false);

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
