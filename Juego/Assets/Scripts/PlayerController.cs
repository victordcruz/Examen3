using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float horizontalmovement = 0f;

    [SerializeField] private float velocitymovement;
    [SerializeField] private float motionsmoothing;

    private Vector3 velocity = Vector3.zero;
    private bool lookingright = true;

    [Header("Jump")]
    [SerializeField] private float Jumpforce;
    [SerializeField] private LayerMask WhatisFloor;
    [SerializeField] private Transform FloorController;
    [SerializeField] private Vector3 Box;
    [SerializeField] private bool InFloor; 

    private bool Jump = false;

    [Header("Animation")]
    private Animator animator; 
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontalmovement = Input.GetAxisRaw("Horizontal") * velocitymovement;

        animator.SetFloat("Horizontal",Mathf.Abs(horizontalmovement));

        if (Input.GetButtonDown("Jump"))
        {
            Jump = true;
        }
    }

    private void FixedUpdate()
    {
        Move(horizontalmovement * Time.fixedDeltaTime, Jump);
        InFloor = Physics2D.OverlapBox(FloorController.position, Box, 0f, WhatisFloor);
        animator.SetBool("InFloor",InFloor);

        Jump = false;
    }

    private void Move(float move, bool InJump)
    {
        Vector3 Objectvelocity = new Vector2(move, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, Objectvelocity, ref velocity, motionsmoothing);

        if(move > 0 && !lookingright)
        {
            Spin();
        }
        else if(move < 0 && lookingright)
        {
            Spin();
        }
        
        if(InFloor && InJump)
        {
            InFloor = false;
            rb2D.AddForce(new Vector2(0f, Jumpforce));
        }
    }

    private void Spin()
    {
        lookingright = !lookingright;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(FloorController.position, Box);
    }

}
