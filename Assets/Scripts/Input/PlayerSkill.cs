using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSkill:MonoBehaviour
{
    
    PlayerMove player;
    [SerializeField] SpriteRenderer PlayerSprite;
    private static CircleCollider2D PlayerCollider;
    [SerializeField] BoxCollider2D PlayerBoxCollider;
    public bool Invis = false;
    [SerializeField] TrailRenderer TrailRend;



    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerMove>();
        PlayerCollider = player.GetComponent<CircleCollider2D>();
        PlayerBoxCollider = player.GetComponentInChildren<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")){
            OnBecameInvisible();
            Invis =!Invis;
            
        }
        
    }

    public void OnBecameInvisible()
    {
        if (Invis == false)
        {
            PlayerSprite.color = new Color(188, 0, 255, 255);
            PlayerCollider.radius = 0;
            PlayerBoxCollider.isTrigger = true;
            TrailRend.emitting = true;

        }
        else
        {
            PlayerSprite.color = new Color(188, 0, 255, 0.25f);
            PlayerCollider.radius = 0;
            PlayerBoxCollider.isTrigger = false;
            TrailRend.emitting = false;
        }
    }
}