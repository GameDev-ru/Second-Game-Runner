using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBuilder : MonoBehaviour
{
    public GameObject[] freePlatforms;
    public GameObject[] startPlarforms;
    public GameObject[] obstaclePlatforms;
    public Transform platformConatainer;

    private Transform lastPlatform=null;

    private bool isObstacle;
    private int isObs = 0;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            CreatePlatform();
        }
    }

    public void Init()
    {
        CreateFreePlatform();
        CreateFreePlatform();
        CreateFreePlatform();
        
        CreateStartPlatform();
        for( int i = 0; i<7; i++)
        {
            CreatePlatform();
        }
    }

    public void CreatePlatform()
    {
        if (isObstacle)
            CreateFreePlatform();
        else CreateObstaclePlatform();
         
    }

    private void CreateFreePlatform()
    {
        Vector3 pos = (lastPlatform == null) ?
            platformConatainer.position :
            lastPlatform.GetComponent<PlatformController>().endPOint.position;
        
        int index = Random.Range(0, freePlatforms.Length);
        GameObject res = Instantiate(freePlatforms[index], pos, Quaternion.identity, platformConatainer);
        lastPlatform = res.transform;

        isObstacle = false;
        isObs = 0;
    }

    private void CreateStartPlatform()
    {
        Vector3 pos = (lastPlatform == null) ?
            platformConatainer.position :
            lastPlatform.GetComponent<PlatformController>().endPOint.position;

        int index = Random.Range(0, startPlarforms.Length);
        GameObject res = Instantiate(startPlarforms[index], pos, Quaternion.identity, platformConatainer);
        lastPlatform = res.transform;


    }

    private void CreateObstaclePlatform()
    {
        Vector3 pos = (lastPlatform == null) ?
            platformConatainer.position :
            lastPlatform.GetComponent<PlatformController>().endPOint.position;

        int index = Random.Range(0, obstaclePlatforms.Length);
        GameObject res = Instantiate(obstaclePlatforms[index], pos, Quaternion.identity, platformConatainer);
        lastPlatform = res.transform;

        isObs++;
        if(isObs==5)
        isObstacle = true;
    }
}
