using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FogedBehav : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    CircleCollider2D circle;
    bool PlayerInCircle = false;

    public PlayerController player = null;

    float directionInterval = 1f;
    float lastChange = 0;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastChange > directionInterval && !PlayerInCircle)
        {
            //Debug.Log(Time.time);
            MoveFoged(new Vector3(Random.Range(-1, 1), Random.Range(-1, 1),0));
            lastChange = Time.time;
        }
        else if (PlayerInCircle)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * 5);
        }
        if (PlayerInCircle && Vector3.Distance(player.transform.position, transform.position ) > 3f)
        {
            animator.Play("Char_Suprise");
        }
    }   

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerInCircle = true;
        }
        //Debug.Log(PlayerInCircle);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerInCircle = false;
        }
        //Debug.Log(PlayerInCircle);
    }

    void MoveFoged(Vector3 thisWay)
    {

        rb.velocity = thisWay;
        //Debug.Log(rb.velocity.magnitude);
        if (rb.velocity.magnitude > 0)
        {
            animator.SetBool("Running", true);

            //Debug.Log("Walking");         
        }
        else
        {
            animator.SetBool("Running", false);
            //Debug.Log("Stop");
        }
    }


    void KillPlayer()
    {
        if (PlayerInCircle)
        {
            Destroy(player);
            SceneManager.LoadScene(0);
        }
    }
}
