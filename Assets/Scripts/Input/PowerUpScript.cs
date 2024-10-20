using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PowerUpScript : MonoBehaviour

{
    CircleCollider2D circleCollider;
    [SerializeField] Light2D light;
    enum PowerBuffs
    {
        BUFF_SPEED,

        BUFF_INVINC,

        BUFF_SEE,
    }
    public PlayerMove script;

    PowerBuffs RandomPower;

    public GameObject Player;


    bool countTime = false;
    public float targetTime = 3.0f;
    
    float realTime = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        //circleCollider = GetComponent<CircleCollider2D>();
        //light = GameObject.Find("FunnyLight").GetComponent<Light2D>();
      
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
            Debug.Log("PlayerHit");
            script.speed = 7.0f;
            countTime = true;
        }
        if(RandomPower == PowerBuffs.BUFF_INVINC)
        {
            circleCollider.enabled = false;
            countTime = true;
        }

        if(RandomPower == PowerBuffs.BUFF_SEE)
        {
            light.pointLightInnerRadius = 5.0f;
            light.pointLightOuterRadius = 10.0f;
            countTime = true;
        }
        Destroy (gameObject);
    }

    void RemoveBuff()
    {
        script.speed = 4.0f;
        //circleCollider.enabled = true;
        countTime = false;
       // light.pointLightInnerRadius = 1.0f;
        //light.pointLightOuterRadius = 5.0f;
        



    }
}
