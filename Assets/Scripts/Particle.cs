using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public GameObject player;
    public bool ground;
    public bool die;
    public ParticleSystem particle;
    
    void Update() 
    {
        ground = player.GetComponent<Controller>().blockDown;
        die = player.GetComponent<Controller>().death;

        if (ground && !die) particle.Play();
        else particle.Pause();
    }


}
