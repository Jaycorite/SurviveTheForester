using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionScript : MonoBehaviour
{
    CircleCollider2D dectionZone;
    IInteractable interactable;
    IPickEmUp pickUpAble;
    IBreakable breakable;
    [SerializeField]
    public ItemController tool;
    bool focus = false;
    public List<GameObject> list;

    // Start is called before the first frame update
    void Start()
    {
        dectionZone = GetComponent<CircleCollider2D>();
        list = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (dectionZone.IsTouching(tree))
        {
            dectionZone.IsTouchingLayers(9);
            Debug.Log("HEJ");
        }*/
        if (focus && Input.GetKey(KeyCode.E))
        {
            //interactable.PrimaryUse();

        }
        if (breakable != null && Input.GetKeyDown(KeyCode.E))
        {
            breakable.Break(tool);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //SimpleTest(collision);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("COLLISION");
        interactable = collision.gameObject.GetComponent<IInteractable>();
        if (interactable != null)
        {
            interactable.Focus();
            focus = true;
        }
        pickUpAble = collision.gameObject.GetComponent<IPickEmUp>();
        breakable = collision.gameObject.GetComponent<IBreakable>();
        //Debug.Log(collision.gameObject.name);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        interactable = collision.gameObject.GetComponent<IInteractable>();
        if (interactable != null)
        {
            interactable.Unfocus();
            focus = false;
            interactable = null;
        }
    }
}
