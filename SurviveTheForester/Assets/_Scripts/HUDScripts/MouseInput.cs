using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    GameObject getThis;
    Transform oldParent;
    public Camera camera;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        Debug.Log("Down");
        //Collider2D col = Physics2D.OverlapPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
       
        Vector3 mouse = Input.mousePosition;

        Vector3 here = camera.ScreenToWorldPoint(mouse);
        //Vector2 vec = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector2 vec = new Vector2(here.x, here.y);
        float mouseXvalue = Input.GetAxis("Mouse X");
        float mouseYvalue = Input.GetAxis("Mouse Y");

        GameObject o = Physics2D.OverlapCircle(vec , 1).gameObject;
        getThis = o;
        oldParent = getThis.transform.parent;
    }

    private void OnMouseDrag()
    {
        Debug.Log("Drag");
        Vector3 pos;
        while (Input.GetMouseButton(1))
        {
            Vector3 mouse = Input.mousePosition;

            Vector3 here = camera.ScreenToWorldPoint(mouse);

            pos = here;

            getThis.transform.position = pos;
        }
    }
    private void OnMouseUp()
    {
        Debug.Log("Up");
        Vector3 mouse = Input.mousePosition;
        Vector3 here = camera.ScreenToWorldPoint(mouse);
        Vector2 vec = new Vector2(here.x, here.y);
        if (Physics2D.OverlapCircle(vec, 1).gameObject.CompareTag("InventorySlot"))
        {
            Transform newParent = Physics2D.OverlapCircle(vec, 1).gameObject.transform;

            getThis.transform.position = newParent.position;
        }
        else
        {
            getThis.transform.position = oldParent.position;
        }

    }
}
