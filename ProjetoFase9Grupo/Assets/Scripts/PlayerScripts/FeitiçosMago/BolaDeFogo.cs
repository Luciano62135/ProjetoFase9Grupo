using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaDeFogo : MonoBehaviour
{
    private Rigidbody rb;
    public int velocidade;

    public GameObject mago;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * velocidade;
    }
}
