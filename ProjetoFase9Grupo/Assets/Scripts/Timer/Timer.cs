using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float tempo;
    public bool estaJogando = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (estaJogando == true)
        {
            tempo += Time.deltaTime;
        }
    }
}
