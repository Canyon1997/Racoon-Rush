using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerScript : MonoBehaviour
{
    public AudioSource hipjazz;

    private float musicVolume = 1f;
    void Start()
    {
        hipjazz.Play();
    }

    // Update is called once per frame
    void Update()
    {
        hipjazz.volume = musicVolume;
    }

    public void UpdateVolume(float volume)
    {
        musicVolume = volume;
    }
}
