using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Transform endPOint;
    public PlatformController platformController;
    // Start is called before the first frame update
    void Start()
    {
        WorlController.instance.OnPlatformMovement += TryDelAndAddPlanform;
    }
    
    private void TryDelAndAddPlanform()
    {
        if (transform.position.z < WorlController.instance.minZ)
        {
            WorlController.instance.worldBuilder.CreatePlatform();
           
            Destroy(gameObject);
        }

    }
     
      
    private void OnDestroy()
    {
        if(WorlController.instance != null)
        WorlController.instance.OnPlatformMovement -= TryDelAndAddPlanform;
    }
}
