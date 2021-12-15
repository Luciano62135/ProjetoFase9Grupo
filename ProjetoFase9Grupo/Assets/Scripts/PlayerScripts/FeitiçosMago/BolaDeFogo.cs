using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaDeFogo : MonoBehaviour
{
    private Rigidbody rb;
    public int velocidade;

    public GameObject mago;

    private float dano;

    public int danoMinimo, danoMaximo;

    MagoScript magoScript;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * velocidade;
        dano = Random.RandomRange(15, 18);
    }

    private void OnTriggerEnter(Collider other)
    {
        magoScript = GameObject.FindGameObjectWithTag("Player").GetComponent<MagoScript>();
        if (other.tag == "InimigoEsqueleto" && magoScript.estaAtacando == true)
        {
            FindObjectOfType<Audio__Manager>().Play("DanoNoEsqueleto");
            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano);
        }
        else if (other.tag == "InimigoGuarda" && magoScript.estaAtacando == true)
        {
            FindObjectOfType<Audio__Manager>().Play("DanoGuarda");
            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano);
        }
        else if (other.tag == "Boss" && magoScript.estaAtacando == true)
        {
            FindObjectOfType<Audio__Manager>().Play("DanoBoss");
            other.gameObject.GetComponent<VidaInimigoScript>().TakeDamage(dano);
        }
    }
}
