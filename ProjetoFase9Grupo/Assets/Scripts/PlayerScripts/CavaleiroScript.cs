using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavaleiroScript : MonoBehaviour
{
    public Animator anim;

    public float velocidadeDeMovimento;

    private Rigidbody rig;

    private Vector3 BotaoDeMovimento;
    private Vector3 moveVelocity;

    private Camera camera;

    public float vidaAtual;
    public float vidaMaxima = 100;

    public bool estaAtacando = false;

    private PlayerHud playerHud;

    public BarraDeVida barraDeVida;

    //[SerializeField]
    //private PhotonView pv;
    void Start()
    {
        vidaAtual = vidaMaxima;
        barraDeVida.SetarVidaMaxima(vidaMaxima);

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
        BotoesDeMovimento();

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

    public void BotoesDeMovimento()
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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetBool("AtacandoNormal", true);
        }
        else
        {
            anim.SetBool("AtacandoNormal", false);
        }
    }

    /*Esses botões de interação sera usado para fazer o player usar itens consumiveis como a poção de vida, os outros tipos de interaçao
     * como abrir portas ou pegar itens vai ficar em scripts separados.
    */
    public void BotoesDeInteracao()
    {
        if (Input.GetButtonDown("UsarCura") && playerHud.pocoes > 0)
        {
            playerHud.pocoes--;
            vidaAtual += playerHud.cura;
            if (vidaAtual > vidaMaxima)
            {
                vidaAtual = vidaMaxima;
            }
        }
    }

    public void TakeDamage(float dano)
    {
        vidaAtual -= dano;
        barraDeVida.SetarVida(vidaAtual);
        if (vidaAtual <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
}
