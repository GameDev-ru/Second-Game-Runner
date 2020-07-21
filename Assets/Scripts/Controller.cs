using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    private float distance = 3f;
    private float distanceClimb = 1f;

    private Animator animator;
    private CharacterController cc;

    private float time;
    private float timeClimb;
    private float currentDistance;
    private float currentDir = 0f;

    private bool isInMovement = false;

    private float roads;

    public GameObject Player;

    private float speed = 0.0001f;
    private float dir;

    public float GravityY = 0.14f;
    private float Ups = 4;
    private float gravity = 0.6f;
    private Vector3 Gravity = Vector3.down;
    private float distUp;

   // private Collider[] colliders;

    [HideInInspector]
    public bool death;
    [HideInInspector]
    public bool blockDown;
    [HideInInspector]
    public bool up;
    [HideInInspector]
    public bool climb;
    [HideInInspector]
    public bool fly;




    void Start()
    {
        cc = GetComponent<CharacterController>();
        death = false;
        climb = false;
        up = false;

        animator = GetComponent<Animator>();

        setRBState(true);

        
        RuntimeAnimatorController ac = animator.runtimeAnimatorController;
        for (int i = 0; i < ac.animationClips.Length; i++)
        {
            if (ac.animationClips[i].name == "run_left")
            {
                time = ac.animationClips[i].length;
            }
            if (ac.animationClips[i].name == "Sprint To Wall Climb")
            {
                timeClimb = ac.animationClips[i].length;
            }
        }
        
    }

    private void FixedUpdate()
    {
        if (up)
        {
            Up();
        }


        StartCoroutine(_Move());

    }

    IEnumerator _Move()
    {

        while (isInMovement)
        {
            if (currentDistance <= 0)
            {
                if (currentDir == 1)
                {
                    roads++;
                }
                if (currentDir == -1)
                {
                    roads--;
                }
            }

            if (currentDistance <= 0)
            {
                isInMovement = false;
                yield return null;
            }

            if (roads == -1 && currentDir == -1 || roads == 1 && currentDir == 1) currentDir = 0;
            float speed = distance / time;
            float tmpDist = Time.deltaTime * speed / 2;
            
            cc.Move(new Vector3(tmpDist * currentDir, 0, 0));
            currentDistance -= tmpDist;

            yield return null;
        }
    }

    void Update()
    {
        if (!death && !up)
        {
            if (Input.GetKeyDown(KeyCode.Space) && cc.isGrounded && !isInMovement)
            {
                Gravity.y = GravityY;
                animator.SetTrigger("Jump");
                return;
            }
            cc.Move(new Vector3(0, Gravity.y, speed));
        }

        if (cc.isGrounded)
        {
            dir = Input.GetAxisRaw("Horizontal");
            if (Gravity.y >= -0.1f)
            Gravity.y -= GravityY;
        }
        if (!cc.isGrounded)
        {
            Gravity.y -= gravity * Time.deltaTime;
        }
        
        StartCoroutine(Animation());
        if (death)
        {
            StartCoroutine(Death());
            StartCoroutine(Restart());
        }
    }

    IEnumerator Death()
    {
        currentDistance = 0;
        speed = 0;
        animator.enabled = false;
        setCollidersState(false);
        setRBState(false);
        yield return null;
    }

    void setRBState(bool state)
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = state;
        }
        //GetComponent<Rigidbody>().isKinematic = !state;
    }
        
    void setCollidersState(bool state)
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();
        foreach(Collider collider in colliders)
        {
            
            collider.isTrigger = state;
        }
        
    }

    IEnumerator Animation()
    {
        yield return new WaitForEndOfFrame();
        if (!fly)
        {
            animator.SetBool("Fly", false);
            animator.SetTrigger("Roll");
            
           
        }

        if (fly)
        {
            animator.SetBool("Fly", true);
            fly = false;
            
        }
        if (!death && !climb && !up)
        {
            if (roads != 1 && dir > 0 || roads != -1 && dir < 0)
                if (isInMovement == false && dir != 0)
                {
                    isInMovement = true;
                    currentDir = dir;
                    currentDistance = distance;

                    if (dir > 0 && roads < 1)
                    {
                        animator.SetTrigger("Right");
                    }
                    if (dir < 0 && roads > -1)
                    {
                        animator.SetTrigger("Left");
                    }
                }
        }
    }



    private void Up()
    {
        if (distUp <= 0)
        {
            up = false;
        }
        float speedUp = distanceClimb / timeClimb * Time.deltaTime * 2;
        if (Player.transform.position.y >= 2.1194)
        {
            Ups = 0;
            return;
        }
        cc.Move(new Vector3(0, speedUp * Ups, 0.1f));
        if (cc.isGrounded) up = false;
        distUp -= speedUp * 1.5f;
    }

   

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Climb"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                climb = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("DeadZone") && !climb && !up)/////////
        {
            death = true;
        }
        if (other.CompareTag("fly"))
        {
            fly = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Climb"))
        {
            if (climb)
            {
                up = true;
                distUp = distanceClimb - 0.3f;
                animator.SetTrigger("Climb");
                climb = false;
            }
        }
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Scene");
    }
}
