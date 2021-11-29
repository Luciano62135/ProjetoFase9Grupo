using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class FeitiçoMago : MonoBehaviour
{
    public GameObject bolaDeFogo;
    public float delay;

    [SerializeField]
    private PhotonView pv;
    // Start is called before the first frame update
    void Start()
    {
        pv = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pv.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Instantiate(bolaDeFogo, transform.position, transform.rotation);
            }
        }
    }
}
