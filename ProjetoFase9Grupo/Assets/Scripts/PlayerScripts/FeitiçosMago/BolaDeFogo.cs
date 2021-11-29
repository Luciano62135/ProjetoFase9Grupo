using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaDeFogo : MonoBehaviour
{
    private Rigidbody rg;
    public int velocidade;

    public GameObject mago;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        mago.transform.forward = transform.position;
        rg.velocity = transform.position * velocidade;
    }
}
