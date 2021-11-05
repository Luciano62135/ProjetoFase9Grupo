using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocoesGeral : MonoBehaviour
{
    private PlayerHud playerhud;
    // Start is called before the first frame update
    void Start()
    {
        playerhud = GameObject.Find("Canvas").GetComponent<PlayerHud>();
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            FindObjectOfType<Audio__Manager>().Play("Coletar");
            playerhud.pocoes++;
            Destroy(this.gameObject);
        }
    }
}
