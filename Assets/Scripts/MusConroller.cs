using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusConroller : MonoBehaviour
{
    private AudioSource sound;


    public AudioClip start;

    public GameObject player;
    public bool die;

    // Start is called before the first frame update
    void Awake()
    {
       
        sound = GetComponent<AudioSource>();
        sound.clip = start;
    }

    // Update is called once per frame
    void Update()
    {

     die = player.gameObject.GetComponent<Controller>().death;
        if (die)
        {
            sound.Stop();


        }

    }
}
