using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFail : MonoBehaviour
{
    public GameObject player;
    public bool death;
    public ParticleSystem particle;

    private void Start()
    {
        particle.Pause();
    }
    void Update()
    {
        death = player.GetComponent<Controller>().death;
        if (death) StartCoroutine(Part());
        
    }

    IEnumerator Part()
    {
        yield return new WaitForSeconds(1.8f);
        particle.Play();
    }
}
