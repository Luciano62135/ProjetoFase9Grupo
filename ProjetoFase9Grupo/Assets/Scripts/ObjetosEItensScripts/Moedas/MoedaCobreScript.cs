using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoedaCobreScript : MonoBehaviour
{
    public int numeroDeMoedas;

    private PlayerHud playerHud;
    // Start is called before the first frame update
    void Start()
    {
        playerHud = GameObject.Find("Canvas").GetComponent<PlayerHud>();
        numeroDeMoedas = Random.RandomRange(3, 7);
    }
    public void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            playerHud.Moedas += numeroDeMoedas;
            Destroy(this.gameObject);
        }
    }
}
