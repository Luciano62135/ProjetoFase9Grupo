using UnityEngine.Audio;
using System;
using UnityEngine;

public class Audio__Manager : MonoBehaviour
{

    public Sound[] sounds;

    void Start()
    {
        FindObjectOfType<Audio__Manager>().Play("musicaDeFundo");
    }
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
