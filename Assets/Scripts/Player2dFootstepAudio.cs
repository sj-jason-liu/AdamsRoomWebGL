using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2dFootstepAudio : MonoBehaviour
{
    private AudioSource _audio;
    
    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        if(_audio == null)
            Debug.LogError("AudioSource is NULL!");
    }

    public void FootstepSound(AudioClip audio)
    {
        _audio.PlayOneShot(audio);
    }
}
