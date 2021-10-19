using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PaladinoScript : PlayersManager
{
    ArmasPlayersScript arma;
    public Animator anim;
    private PlayerHud playerHud;
    private Rigidbody rig;
    private Camera camera;
    void Start()
    {
        arma = GetComponent<ArmasPlayersScript>();
        playerHud = GameObject.Find("Canvas").GetComponent<PlayerHud>();
        // pv = GetComponent<PhotonView>();
        rig = GetComponent<Rigidbody>();
        camera = FindObjectOfType<Camera>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        BotoesDeInteracao();
        BotoesDeMovimentacao();

        Ray cameraRay = camera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLenght;

        if (groundPlane.Raycast(cameraRay, out rayLenght))
        {
            Vector3 pontoPraOlhar = cameraRay.GetPoint(rayLenght);
            Debug.DrawLine(cameraRay.origin, pontoPraOlhar, Color.blue);

            transform.LookAt(new Vector3(pontoPraOlhar.x, transform.position.y, pontoPraOlhar.z));
        }
    }

    public void BotoesDeMovimentacao()
    {
        if (Input.GetKey(KeyCode.W) && estaAtacando == false)
        {
            transform.Translate(new Vector3(0, 0, 4 * Time.deltaTime));
            anim.SetBool("AndandoFrente", true);
        }
        else
        {
            anim.SetBool("AndandoFrente", false);
        }
        if (Input.GetKey(KeyCode.S) && estaAtacando == false)
        {
            transform.Translate(new Vector3(0, 0, -4 * Time.deltaTime));
            anim.SetBool("AndandoTras", true);
        }
        else
        {
            anim.SetBool("AndandoTras", false);
        }
        if (Input.GetKey(KeyCode.D) && estaAtacando == false)
        {
            transform.Translate(new Vector3(4 * Time.deltaTime, 0, 0));
            anim.SetBool("AndandoDireita", true);
        }
        else
        {
            anim.SetBool("AndandoDireita", false);
        }
        if (Input.GetKey(KeyCode.A) && estaAtacando == false)
        {
            transform.Translate(new Vector3(-4 * Time.deltaTime, 0, 0));
            anim.SetBool("AndandoEsquerda", true);
        }
        else
        {
            anim.SetBool("AndandoEsquerda", false);
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            anim.SetBool("AndandoEsquerda", false);
            anim.SetBool("AndandoDireita", false);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            anim.SetBool("AndandoFrente", false);
            anim.SetBool("AndandoTras", false);
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            anim.SetBool("AtaqueNormal", true);
            estaAtacando = true;
        }
        else
        {
            anim.SetBool("AtaqueNormal", false);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Mouse1))
        {
            transform.Translate(new Vector3(0, 0, -3 * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Mouse1))
        {
            transform.Translate(new Vector3(0, 0, 3 * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Mouse1))
        {
            transform.Translate(new Vector3(-3 * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.Mouse1))
        {
            transform.Translate(new Vector3(3 * Time.deltaTime, 0, 0));
        }
    }



    /*Esses botões de interação sera usado para fazer o player usar itens consumiveis como a poção de vida, os outros tipos de interaçao
     * como abrir portas ou pegar itens vai ficar em scripts separados.
    */
    public void BotoesDeInteracao()
    {
        if (Input.GetButtonDown("UsarCura") && playerHud.pocoes > 0)
        {
            vidaAtual += playerHud.cura;
            playerHud.pocoes--;
            if (vidaAtual > vidaMaxima)
            {
                vidaAtual = vidaMaxima;
            }
        }
    }
}
