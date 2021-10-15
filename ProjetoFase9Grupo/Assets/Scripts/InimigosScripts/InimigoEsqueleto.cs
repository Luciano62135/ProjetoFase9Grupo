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
    public bool estaAtacando = false;
    public int numeroDoAtaque;

    //estados (no caso oque vai ativar os estados)
    public float alcanceDeVisao, AlcanceDoAtaque;

    //teste para pegar a posicao do player
    public Vector3 posicaoPlayer;

    // vida
    public float vidaAtual;
    public float vidaMaxima = 100;
    public BarraDeVida barraDeVida;

    public void Start()
    {
        vidaAtual = vidaMaxima;
        barraDeVida.SetarVidaMaxima(vidaMaxima);
        esqueletoAnim = GetComponent<Animator>();
    }

    public void Update()
    {
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
                    agent.isStopped = true;
                    Invoke(nameof(TempoEntreOAtaque), tempoEntreOAtaque);
                }
                if (numeroDoAtaque == 2)
                {
                    esqueletoAnim.SetBool("Andando", false);
                    esqueletoAnim.SetBool("Atacando2", true);
                    agent.isStopped = true;
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

    public void TakeDamage(float dano)
    {
        vidaAtual -= dano;
        barraDeVida.SetarVida(vidaAtual);
        if (vidaAtual <= 0f)
        {
            Destroy(this.gameObject);
        }
    }


}
