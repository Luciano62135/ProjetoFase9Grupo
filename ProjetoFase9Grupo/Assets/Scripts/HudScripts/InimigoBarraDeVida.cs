using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoBarraDeVida : MonoBehaviour
{
    [SerializeField]
    private Transform cam;

    void LateUpdate()
    {
        cam = GameObject.FindGameObjectWithTag("CameraPlayer").GetComponent<Transform>();
        transform.LookAt(transform.position + cam.forward);
    }
}
