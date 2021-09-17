using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CharacterController : MonoBehaviour
{
    public float velocidadeDeMovimento;
    private Rigidbody rig;

    private Vector3 BotaoDeMovimento;
    private Vector3 moveVelocity;

    private Camera camera;

    public float vida = 100;

    //[SerializeField]
    //private PhotonView pv;
    // Start is called before the first frame update
    void Start()
    {
       // pv = GetComponent<PhotonView>();
        rig = GetComponent<Rigidbody>();
        camera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 0, 6 * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, -6 * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3( 6 * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3( -6 * Time.deltaTime, 0, 0));
        }


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

    void FixedUpdate()
    {

    }
}
