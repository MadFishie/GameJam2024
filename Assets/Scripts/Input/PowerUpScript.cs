using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour

{

    enum PowerBuffs
    {
        BUFF_SPEED,
        BUFF_HIDE,
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
            RandomPower = (PowerBuffs) Random.RandomRange(1,3);
            Debug.Log("PlayerHit");
            Debug.Log(RandomPower);
        }
        if(RandomPower == PowerBuffs.BUFF_SPEED) {
            script.speed = 10f;
        }
        if(RandomPower == PowerBuffs.BUFF_HIDE)
        {
            
        }
    }

    void RemoveBuff()
    {


    }
}
