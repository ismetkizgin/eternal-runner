using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound_script : MonoBehaviour
{
    public AudioSource sound;
    
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "death")
            sound.Play();
    }
    

    void Update()
    {
        sound.Stop();
    }
}
