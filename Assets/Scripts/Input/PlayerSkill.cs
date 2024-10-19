using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill:MonoBehaviour
{
    
    PlayerMove player;
    [SerializeField] SpriteRenderer PlayerSprite;
    private static CircleCollider2D PlayerCollider;
    [SerializeField] BoxCollider2D PlayerBoxCollider;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerMove>();
        PlayerCollider = player.GetComponent<CircleCollider2D>();
        PlayerBoxCollider = player.GetComponent<BoxCollider2D>();
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
            PlayerSprite.color = Color.white;
            PlayerCollider.radius = 0;
            PlayerBoxCollider.isTrigger = false;

        }
    }
}
