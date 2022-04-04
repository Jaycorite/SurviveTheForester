using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    public Collider2D collider2d;
    [SerializeField] float movementSpeed = 6f;
    public ItemController tool;
    [HideInInspector]
    public AudioManager audioManager;
    IBreakable breakable;
    IInteractable mainInteractable;
    Transform mainInteractableTrans;
    public int Health = 20;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            audioManager.Play("Pick_Up");
        }*/
        MovePlayer();
        if (Input.GetKeyDown(KeyCode.E))
        {
            PrimaryAction();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Detect(collision);
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Remove(collision);
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        rb.velocity = new Vector2(horizontalInput * movementSpeed, verticalInput * movementSpeed);
        //Debug.Log(rb.velocity.magnitude);
        if (rb.velocity.magnitude > 0)
        {
            animator.SetBool("Running", true);
            
            //Debug.Log("Walking");         
        }
        else
        {
            animator.SetBool("Running", false);
            audioManager.Play("Walking");
            //Debug.Log("Stop");
        }
    }

    void PrimaryAction()
    {
        if (breakable != null && tool != null)
        {
            
            breakable.Break(tool);
            animator.Play("Char_Chop");
            audioManager.Play("Chop");
        }
        if (mainInteractable != null)
        {
            mainInteractable.PrimaryUse();

        }
    }

    void Detect(Collider2D collision)
    {
        IInteractable interactable = collision.gameObject.GetComponent<IInteractable>();
        
        if(interactable == null)
        {
            mainInteractable = null;
        }
        else if (interactable != null)
        {
            if(mainInteractable == null)
            {
                mainInteractable = interactable;
                mainInteractableTrans = collision.transform;
                mainInteractable.Focus();
            }
            else if(mainInteractable != null && Vector3.Distance(mainInteractableTrans.position, this.transform.position) > Vector3.Distance(collision.transform.position, this.transform.position))
            {
                mainInteractable.Unfocus();
                mainInteractable = interactable;
                mainInteractableTrans = collision.transform;
                mainInteractable.Focus();
            }
        }

        breakable = collision.gameObject.GetComponent<IBreakable>();
    }

    void Remove(Collider2D collision)
    {
        IInteractable interactable = collision.gameObject.GetComponent<IInteractable>();
        if (interactable != null)
        {
            if(mainInteractable == interactable)
            {
                mainInteractable.Unfocus();
                mainInteractable = null;
            }
        }
    }
}
