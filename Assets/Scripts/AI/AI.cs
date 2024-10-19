using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DefaultExecutionOrder(-10)]
[RequireComponent(typeof(AIMove))]
public class AI : MonoBehaviour
{



    public AIMove movement { get; private set; }

    public Transform target;
    public int points = 200;

    private void Awake()
    {
        movement = GetComponent<AIMove>();

    }

   
   
    public void SetPosition(Vector3 position)
    {
        // Keep the z-position the same since it determines draw depth
        position.z = transform.position.z;
        transform.position = position;
    }

   
}
