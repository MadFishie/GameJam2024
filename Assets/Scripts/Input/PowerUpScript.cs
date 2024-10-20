using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PowerUpScript : MonoBehaviour

{

    CircleCollider2D circleCollider;
    enum PowerBuffs
    {
        BUFF_SPEED,

        BUFF_INVINC
    }
    public PlayerMove script;

    PowerBuffs RandomPower;

    public GameObject Player;

    bool countTime = false;
    public float targetTime = 5.0f;
    
    float realTime = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
      
    }

    // Update is called once per frame
    void Update()
    {

        if(countTime == true) {

            realTime += Time.deltaTime;
        }
        if (realTime >= targetTime)
        {
            RemoveBuff();
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            RandomPower = (PowerBuffs) Random.RandomRange(0,1);
            Debug.Log("PlayerHit");
            Debug.Log(RandomPower);
        }
        if(RandomPower == PowerBuffs.BUFF_SPEED) {
            script.speed = 10f;
        }
        if(RandomPower == PowerBuffs.BUFF_INVINC)
        {
            circleCollider.enabled = false;
        }
    }

    void RemoveBuff()
    {
        script.speed = 5.0f;
        circleCollider.enabled = true;



    }
}
