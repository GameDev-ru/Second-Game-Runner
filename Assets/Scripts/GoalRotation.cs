using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalRotation : MonoBehaviour
{


    public float speed ;

    private void FixedUpdate()
    {
        //Quaternion rotatyionY = Quaternion.AngleAxis(speedRotation, Vector3.forward);
        //transform.rotation *= rotatyionY;
        //if (transform.rotation.z == transform.position.z+90)
        //{
        //    Debug.Log("+");
        //    rotatyionY = Quaternion.AngleAxis(0, Vector3.zero);
        //}


        StartCoroutine(Door());
        
    }

    IEnumerator Door()  
    {
        
        transform.Rotate(0, 0, speed * Time.deltaTime);
        yield return new WaitForSeconds(7);
        speed = 0;

    }
}
