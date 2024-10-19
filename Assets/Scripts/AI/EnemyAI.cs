using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyAI : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float speed;

    Vector2[] directions = { Vector2.up, Vector2.right, Vector2.down, Vector2.left };

    int directionIndex = 1;

    [SerializeField] Vector2 currentDir;
    [SerializeField] float rayDistance;
    [SerializeField] LayerMask rayLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        currentDir = directions[directionIndex];
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
                ChangeDirection();
                Debug.Log("Hit Wall");
            }

            if (hit2D.collider.gameObject.CompareTag("Player"))
            {

                print("Found");
            }
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
