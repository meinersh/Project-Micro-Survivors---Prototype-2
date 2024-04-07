//This is for player inputs and movements

using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject Game_Controller;
    public float moveSpeed;
    public Rigidbody2D rb2D;
    private float moveHorizontal;
    private float moveVertical;

    // Start is called before the first frame update
    void Start()
    {
        //Gets it's own rigidbody2D component.
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        
        //Ignores collision with player bullets
        Physics2D.IgnoreLayerCollision(3, 7, true);
    }

    // Update is called once per frame
    void Update()
    {
        //Gets the input for movement from Unity's input system
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }

    //updates based on realtime.
    private void FixedUpdate()
    {
        //Only runs if there is input in one direction at least.
        if(moveHorizontal > 0.1f || moveHorizontal < -0.1f || moveVertical > 0.1f || moveVertical < -0.1f)
        {
            //Applies force to player object in direction of the input.
            rb2D.AddForce(new Vector2 (moveHorizontal * Game_Control.Player_Speed, moveVertical * Game_Control.Player_Speed), ForceMode2D.Impulse);
        }
    }
}
