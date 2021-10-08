using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoedasGeral : MonoBehaviour
{
    public int numeroDeMoedas;

    public int numeroMaximoDeMoedas;
    public int numeroMinimoDeMoedas;

    private PlayerHud playerHud;
    // Start is called before the first frame update
    void Start()
    {
        playerHud = GameObject.Find("Canvas").GetComponent<PlayerHud>();
        numeroDeMoedas = Random.RandomRange(numeroMinimoDeMoedas, numeroMaximoDeMoedas);
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            playerHud.Moedas += numeroDeMoedas;
            Destroy(this.gameObject);
        }
    }
}
