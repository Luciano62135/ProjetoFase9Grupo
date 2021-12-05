using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSlide : MonoBehaviour
{
    float volumeSliders;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void VolumeSliders(float volume)
    {
        volumeSliders = volume;
        AudioListener.volume = volumeSliders;
    }
}