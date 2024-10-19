using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill:MonoBehaviour
{
    
    PlayerMove player;
    [SerializeField] Sprite PlayerSprite;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        OnBecameInvisible();
    }

    public void OnBecameInvisible()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("AHHH");

        }
    }
}
