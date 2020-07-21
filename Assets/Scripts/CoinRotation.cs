using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Quaternion rotatyionY = Quaternion.AngleAxis(3, Vector3.forward);
        transform.rotation *= rotatyionY;
    }
}
