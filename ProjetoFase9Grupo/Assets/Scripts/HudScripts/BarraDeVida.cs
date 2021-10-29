using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image preenchimentoVida;

    public void SetarVidaMaxima(float vida)
    {
        slider.maxValue = vida;
        slider.value = vida;

        preenchimentoVida.color = gradient.Evaluate(1f);
    }

    public void SetarVida(float vida)
    {
        slider.value = vida;

        preenchimentoVida.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void Update()
    {
        
    }
}
