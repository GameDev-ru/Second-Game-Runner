using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gener : MonoBehaviour
{
    public GameObject block;

    
        void Update()
    {
        GameObject[] _block;
        _block = GameObject.FindGameObjectsWithTag("Block");
        if(_block.Length >= 4)
        {
            Destroy(_block[0]);
        }

    }

    void Generator(Vector3 centre, float radius)
    {
        Collider[] coliders = Physics.OverlapSphere(centre, radius);
        if(coliders.Length == 0)
        {
            Instantiate(block, centre, Quaternion.identity);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            Generator(new Vector3(transform.position.x, 0, transform.position.z + 91.007f), 1f);
        }
    }
}
