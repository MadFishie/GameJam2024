using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]


public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    [Header("Toggle Vals")]
    public float speed = 7f;
    [Header("Reference Vals")]
    [SerializeField]BoxCollider2D HitDetect;
    [SerializeField] Transform playerSprite;
    [SerializeField] float RotSpeed = 3f;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        HitDetect = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {


        var velUpdate = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);
        rb.velocity = velUpdate;

        if (velUpdate != Vector2.zero) 
        {
            Quaternion targetRot = Quaternion.LookRotation(transform.forward, velUpdate);
            Quaternion rot = Quaternion.RotateTowards(transform.rotation, targetRot, RotSpeed);
            playerSprite.rotation = rot;
        }

	}
}
