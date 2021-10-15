using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaInimigoScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ScriptInimigoPai inimigoPai = GetComponent<ScriptInimigoPai>();
        inimigoPai.vidaAtual = inimigoPai.vidaMaxima;
        inimigoPai.barraDeVida.SetarVidaMaxima(inimigoPai.vidaMaxima);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float dano)
    {
        ScriptInimigoPai inimigoPai = GetComponent<ScriptInimigoPai>();
        inimigoPai.vidaAtual -= dano;
        inimigoPai.barraDeVida.SetarVida(inimigoPai.vidaAtual);
        if (inimigoPai.vidaAtual <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
}
