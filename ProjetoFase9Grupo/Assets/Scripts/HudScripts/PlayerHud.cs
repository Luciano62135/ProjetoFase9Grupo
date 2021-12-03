using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour
{
    public int pocoes;
    public Text pocoesText;
    public float cura = 30;

    public int moedas;
    public Text moedasText;

    public Text moedasMercado;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moedasMercado.text = "" + moedas;
        moedasText.text = "" + moedas;
        pocoesText.text = "" + pocoes;
    }
}
