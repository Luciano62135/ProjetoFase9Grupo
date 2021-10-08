using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoEsqueleto : MonoBehaviour
{
    public Animator esqueletoAnim;

    public void Start()
    {
        esqueletoAnim = GetComponent<Animator>();
    }
}
