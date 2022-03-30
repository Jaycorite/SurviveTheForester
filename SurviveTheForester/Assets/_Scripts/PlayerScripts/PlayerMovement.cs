using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    public Collider2D collider2d;
    public BoxCollider2D tree;
    [SerializeField] float movementSpeed = 6f;
    Bounds Bounds => collider2d.bounds;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        Debug.Log("And So It Begins");
    }

    


    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.contactCount);
    }


    void Update()
    {
        bool movement = true;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        
        rb.velocity = new Vector2(horizontalInput * movementSpeed, verticalInput * movementSpeed);
        if (rb.velocity.magnitude > 0)
        {
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }


        //GameObject findThis = GetComponentInChildren<GameObject>();
        //Renderer renderer = findThis.GetComponent<Renderer>();
        /*
        if (box.IsTouchingLayers())
        {
            Debug.Log("Hmmmmm2");
        }
        if (rb.IsTouching(tree))
        {
            Debug.Log("WHAT");
        }*/

    }
}
