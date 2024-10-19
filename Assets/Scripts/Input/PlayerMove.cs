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
    [SerializeField] float speed = 7f;
    [Header("Reference Vals")]
    [SerializeField]BoxCollider2D HitDetect;
    [SerializeField] Transform playerSprite;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        HitDetect = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {


        var velUpdate = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);
        rb.velocity = velUpdate;
        if (velUpdate == Vector2.zero) {return; }
		playerSprite.localScale=new Vector3(Mathf.Sign(velUpdate.x), Mathf.Sign(velUpdate.y));
	}

}
