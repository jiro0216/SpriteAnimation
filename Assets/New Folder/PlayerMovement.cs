using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Variable for our speed modifier
    public float moveSpeed;
    //Variable for our player input
    public Vector2 movementInput;
    //Variable for our RigidBody2D
    public Rigidbody2D rigidBody;

    //Variable  for Animator
    public Animator anim;

    public int coinCounter;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ////While S is pressed run this animation
        //if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    anim.SetTrigger("forwardAnimation");
        //    anim.enabled = true;

        //}
        //if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)) {

        //    anim.enabled = false;


        //}
        ////While W is pressed run this animation
        //if (Input.GetKeyDown(KeyCode.W) ||Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    anim.SetTrigger("backwardAnimation");
        //    anim.enabled = true;
        //}
        //if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) {

        //    anim.enabled = false;
        //}
        ////While A is pressed run this animation
        //if (Input.GetKeyDown(KeyCode.A) ||Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    anim.SetTrigger("leftAnimation");
        //    anim.enabled = true;
        //}
        //if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.UpArrow)) {
        //    anim.enabled = false;

        //}
        ////While D is pressed run this animation
        //if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    anim.SetTrigger("rightAnimation");
        //    anim.enabled = true;
        //}
        //if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        //{
        //    anim.enabled = false;
        //}

        //Gets the horizontal string on animator and adding the movement input x into it.
        anim.SetFloat("Horizontal", movementInput.x);
        //Gets the horizontal string on animator and adding the movement input y into it.
        anim.SetFloat("Vertical",movementInput.y);

        anim.SetFloat("Speed",movementInput.sqrMagnitude);





    }
    
    //Update that handles physics
    private void FixedUpdate()
    {
        rigidBody.velocity = movementInput * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("coin"))
        {
            Destroy(collision.gameObject);
            coinCounter++;
        }
    }
    //Converts our Inputs to Vector
    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }

}
