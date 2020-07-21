using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorlController : MonoBehaviour
{
    public float speed;
    public WorldBuilder worldBuilder;
    public float minZ ;

    public delegate void TryToDelAndAddPlatform();
    public event TryToDelAndAddPlatform OnPlatformMovement;
     
    public static WorlController instance;
    public bool die;
    public bool climb;
    public bool up;

    public GameObject player;
    private void Awake()
    {
        if(WorlController.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        WorlController.instance = this;
    }

    private void OnDestroy()
    {
        WorlController.instance = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Dif",30,30);
        StartCoroutine(OnPlatformMovementCoroutine());
    }

    // Update is called once per frame
    void Update()
    {

        die = player.gameObject.GetComponent<Controller>().death;
        climb = player.gameObject.GetComponent<Controller>().climb;
        up = player.gameObject.GetComponent<Controller>().up;
        if (!die && !up) transform.position -= Vector3.forward * speed * Time.deltaTime;


    }

    public void Dif()
    {
        speed *= 1.2f;
    }

    IEnumerator OnPlatformMovementCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if(OnPlatformMovement!=null)
                OnPlatformMovement();
        }
    }
    
}
