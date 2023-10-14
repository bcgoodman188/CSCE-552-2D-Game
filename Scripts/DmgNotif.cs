using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgNotif : MonoBehaviour
{
    public AudioSource dmgSound;
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy") {
            dmgSound.Play();
        }       
    }
}
