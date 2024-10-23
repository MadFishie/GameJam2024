using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SnakeManage : MonoBehaviour
{
    [SerializeField] float distBetween = .2f;
    [SerializeField] float speed = 280;
    [SerializeField] float turnSpeed = 18;
    [SerializeField] List<GameObject> bodyParts = new List<GameObject>();
    List<GameObject> snakeBody = new List<GameObject>();

    float countUp = 0;

    void Start()
    {
        CreatBodyParts();

    }

    void FixedUpdate()
    {
        if (bodyParts.Count > 0) 
        {
            CreatBodyParts();
        }
        SnakeMovment();
    }

    void SnakeMovment() 
    {
        
        snakeBody[0].GetComponent<Rigidbody2D>().velocity = snakeBody[0].transform.right*speed;
        if (Input.GetAxis("Horizontal") != 0) 
        {
            snakeBody[0].transform.Rotate(new Vector3 (0,0,-turnSpeed*Time.deltaTime*Input.GetAxis("Horizontal")));
        }

        if (snakeBody.Count > 1) 
        {
            for (int i = 1; i < snakeBody.Count; i++) 
            {
                ChunkManagment chunkM = snakeBody[i-1].GetComponent<ChunkManagment>();
                snakeBody[i].transform.position=chunkM.chunks[0].position;
                snakeBody[i].transform.rotation = chunkM.chunks[0].rotation;
                chunkM.chunks.RemoveAt(0);

            }

        }

    }

    void CreatBodyParts() 
    {
        if (snakeBody.Count == 0) 
        {
    
            GameObject temp1 = Instantiate(bodyParts[0],transform.position,transform.rotation,transform);
            if(!temp1.GetComponent<Rigidbody2D>())
                temp1.AddComponent<Rigidbody2D>();

            if (!temp1.GetComponent<Rigidbody2D>()) 
            {
                temp1.AddComponent<Rigidbody2D>();
                temp1.GetComponent<Rigidbody2D>().gravityScale = 0;
            }
            snakeBody.Add(temp1);
            bodyParts.RemoveAt(0);


        }


    
        
        ChunkManagment chunkM = snakeBody[snakeBody.Count-1].GetComponent<ChunkManagment>();

        countUp += Time.deltaTime;
        if (countUp == 0) 
        {
            chunkM.ClearChunksLoaded();
        }
        
        countUp += Time.deltaTime;
        if (countUp>=distBetween) 
        {
            GameObject temp = Instantiate(bodyParts[0], transform.position, transform.rotation, transform);

            if (!temp.GetComponent<ChunkManagment>()) { temp.AddComponent<ChunkManagment>(); }

            if (!temp.GetComponent<Rigidbody2D>())
            {
                temp.AddComponent<Rigidbody2D>();
                temp.GetComponent<Rigidbody2D>().gravityScale = 0;
            }

            snakeBody.Add(temp);
            bodyParts.RemoveAt(0);
            temp.GetComponent<ChunkManagment>().ClearChunksLoaded();
            countUp = 0;
        }

    }


}
