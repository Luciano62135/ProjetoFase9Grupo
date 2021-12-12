using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTesteInimigo : MonoBehaviour
{
    [SerializeField] float distanciaEncontro = 5f;

    GameObject player;

    bool estaPronto;

    [SerializeField]
    private Animator inimigoAnim;
    private void Start()
    {
        
        player = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        if (PlayerNoRaioDeAtaque() && podeAtacar(player))
        {
            estaPronto = true;
        }
        else
        {
            estaPronto = false;
            Cancel();
        }
    }

    private bool podeAtacar(GameObject target)
    {
        if (target == null) { return false; }
        VidaPlayer targetVida = target.GetComponent<VidaPlayer>();
        return targetVida != null && !targetVida.barraDeVida;
    }

    private bool PlayerNoRaioDeAtaque()
    {
        float distanciaDoPlayer = Vector3.Distance(player.transform.position, transform.position);
        return distanciaDoPlayer < distanciaEncontro;
    }

    private void Cancel()
    {
        
    }
}
