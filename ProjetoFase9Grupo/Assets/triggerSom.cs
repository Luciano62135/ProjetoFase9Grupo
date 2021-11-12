using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerSom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<Audio__Manager>().Play("DanoHumano");
    }
}