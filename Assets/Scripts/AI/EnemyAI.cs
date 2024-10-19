using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyAI : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float speed;

    Vector2[] directions = { Vector2.up, Vector2.right, Vector2.down, Vector2.left};

    int directionIndex = 1;

    [SerializeField] Vector2 currentDir;
    [SerializeField] float rayDistance;
    [SerializeField] LayerMask rayLayer;

    Transform PlayerPos;
    bool PlayerChase=false;

    [SerializeField] float intrestTime = 2f;
    float chaseTimer = 0;

    float dirUpdate = 0;
    [SerializeField] float uptDirEvery = .5f; 


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Start()
    {
        currentDir = directions[directionIndex];
        PlayerPos = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {

        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, currentDir, rayDistance, rayLayer);
        Vector3 endpoint = currentDir * rayDistance;
        Debug.DrawLine(transform.position, transform.position + endpoint, Color.green);



        if (hit2D.collider != null)
        {
          
           
            
            if (hit2D.collider.gameObject.CompareTag("Wall"))
            {
                var choice= Random.RandomRange(0, 6);
                
                if(choice>3) {PlayerChase=true; return; }

                ChangeDirection();

                
                Debug.Log("Hit Wall");

            }

            else if (hit2D.collider.gameObject.CompareTag("Player"))
            {
                PlayerChase = true;

            }

        }
   

        if (PlayerChase)
        {
            PlayerChasing();
        }


    }

    private void PlayerChasing()
    {
        try 
        {
            var calcPos = PlayerPos.position - transform.position;


            if (dirUpdate >= uptDirEvery)
            {
                uptDirEvery = 0;
                RaycastHit2D hit2D = Physics2D.Raycast(transform.position, currentDir, rayDistance, rayLayer);
                Vector3 endpoint = currentDir * rayDistance;
                Debug.DrawLine(transform.position, transform.position + endpoint, Color.green);
                if (hit2D.collider.gameObject.CompareTag("Wall"))
                {
                    ChangeDirection();

                }
                else
                {
                    currentDir = new Vector2(Mathf.Clamp(calcPos.x, -1, 1), Mathf.Clamp(calcPos.y, -1, 1));


                }

            }

            chaseTimer += Time.deltaTime;
            dirUpdate += Time.deltaTime;


            if (chaseTimer >= intrestTime)
            {
                chaseTimer = 0;
                PlayerChase = false;

                currentDir = directions[directionIndex];
            }
        }
        catch 
        {
        
        }
        
    
    
    }





    void ChangeDirection()
    {
        directionIndex += Random.Range(0, 2) * 2 - 1;

        int clampedIndex = directionIndex % directions.Length;

        if (clampedIndex < 0)
        {
            clampedIndex = directions.Length + clampedIndex;
        }

        rb.velocity = Vector2.zero;

        currentDir = directions[clampedIndex];
    }

    void FixedUpdate()
    {

        rb.AddForce(currentDir * speed);
    }
}
