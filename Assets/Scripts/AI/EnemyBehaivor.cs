using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyBehaivor : MonoBehaviour
{
    enum enemyState {Chase,Scatter,Frighten };

    
    Transform Player;
    NavMeshAgent agent;
    List<Vector2> EnemyPoints = new List<Vector2>();
    [SerializeField] enemyState currentState;

    float IntrestTimer=0;
    [SerializeField] float timeIntrested = 2f;

    float StateTimer = 0;
    [SerializeField] float cycleCount=.4f;

    Vector2 scatterCurrentEndPoint;


    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;


        foreach(GameObject points in GameObject.FindGameObjectsWithTag("EnemyPoints")) 
        {
            EnemyPoints.Add(points.transform.position);
        }

        scatterCurrentEndPoint = EnemyPoints[Random.Range(0, EnemyPoints.Count - 1)];

    }

    void Update()
    {
        

        PlayerControlState();

        if (currentState == enemyState.Frighten) { return; }

        StateTimer += Time.deltaTime;
        if (StateTimer >= cycleCount) 
        {
            if (currentState == enemyState.Chase) { currentState = enemyState.Scatter; }
            else { currentState = enemyState.Chase; }
            StateTimer = 0;
        }
        


      

    }

    private void PlayerControlState()
    {
        switch (currentState)
        {
            case enemyState.Chase:
                ChasePlayer();
                break;
            case enemyState.Scatter:
                ScatterPlayer();
                break;
            case enemyState.Frighten:
                FrightenPlayer();
                break;

        }
    }

    private void ChasePlayer() 
    {
        agent.SetDestination(Player.position);
        scatterCurrentEndPoint = EnemyPoints[Random.Range(0, EnemyPoints.Count - 1)];
    }

    private void ScatterPlayer() 
    {
        agent.SetDestination(scatterCurrentEndPoint);

        if ((Vector2)transform.position == scatterCurrentEndPoint) 
        {
            scatterCurrentEndPoint = EnemyPoints[Random.Range(0, EnemyPoints.Count - 1)];
            Debug.Log("New point gen");
        }
    
    }

    private void FrightenPlayer() 
    {
    
    }









}
