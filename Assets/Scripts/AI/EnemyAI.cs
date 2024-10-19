using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyAI : MonoBehaviour
{
    enum EnemyStates {Scatter,Chase,Frightened }

    Rigidbody2D rb;

    [SerializeField] float speed;
    [SerializeField] EnemyStates enemyState;

    List<Vector2> MazePoints=new List<Vector2>();






    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        foreach (var point in GameObject.FindGameObjectsWithTag("MazePoints") ) 
        {
            MazePoints.Add(point.transform.position);
        }

    }

    private void Update()
    {
        switch (enemyState) 
        {
            case EnemyStates.Scatter:
                enemyScatter();
                break;
            case EnemyStates.Chase:
                enemyChase();
                break;
            default:
                enemyFright();
                break;
        
        }



    }

    private void enemyScatter() 
    {
        


        foreach (var point in MazePoints) 
        {
            
        
        }


    }

    private void enemyChase()
    {

    }

    private void enemyFright()
    {

    }






}
