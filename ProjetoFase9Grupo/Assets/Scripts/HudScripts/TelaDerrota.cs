using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelaDerrota : MonoBehaviour
{
    public GameObject perdeu;

    //players
    private MachadoScript machado;
    private PaladinoScript paladino;
    private CavaleiroScript cavaleiro;
    private MagoScript mago;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        machado = GameObject.FindGameObjectWithTag("Player").GetComponent<MachadoScript>();
        paladino = GameObject.FindGameObjectWithTag("Player").GetComponent<PaladinoScript>();
        cavaleiro = GameObject.FindGameObjectWithTag("Player").GetComponent<CavaleiroScript>();
        mago = GameObject.FindGameObjectWithTag("Player").GetComponent<MagoScript>();

        if (machado.estaMorto == true || paladino.estaMorto == true || cavaleiro.estaMorto == true || mago.estaMorto == true)
        {
            perdeu.SetActive(true);
        }
    }
}
