using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryInput : MonoBehaviour
{
    GameObject selected;
    GameObject HotBarItem;

    public Hotbar hotbar;
    public InventoryUI inventory;
    public Crafting crafting;
    public GameObject hand;

    Canvas canvas;
    Mouse mouse;
    Keyboard keyboard;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        mouse = Mouse.current;
        keyboard = Keyboard.current;
        crafting.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        //eventSystem.currentInputModule.input.GetMouseButtonDown(1)
        if (mouse.leftButton.wasPressedThisFrame)
        {
            string[] vs = new string[3] { "Book", "Material", "Item" };
            selected = SelectByHere(mouse.position.ReadValue(), vs);
            //Debug.Log(selected);

            
            //Debug.Log(mouse.position.ReadValue());
        }
        else if (selected != null && mouse.leftButton.isPressed)
        {
            Vector3 vec = canvas.worldCamera.ScreenToWorldPoint(mouse.position.ReadValue());
            vec.z = -7;
            selected.transform.position = vec;
            //Debug.Log(selected.transform.position);

            
        }
        else if (selected != null && mouse.leftButton.wasReleasedThisFrame)
        {
            //Debug.Log(mouse.position.ReadValue());
            GameObject inventorySlot = SelectByHere(mouse.position.ReadValue(), new string[2] {"InventorySlot", "Hotbar"});
            //Debug.Log(inventorySlot);
            if (inventorySlot != null)
            {
                if (selected.tag == "Book" && selected.transform.parent == inventorySlot.transform)
                {
                    if (crafting.gameObject.activeSelf == false)
                    {
                        crafting.gameObject.SetActive(true);    
                    }
                    else
                    {
                        crafting.gameObject.SetActive(false);
                    }
                    selected.transform.position = inventorySlot.transform.position;
                    selected.transform.parent = inventorySlot.transform;
                }
                else
                {
                    selected.transform.position = inventorySlot.transform.position;
                    selected.transform.parent = inventorySlot.transform;
                }
                
                
            }
            
        }
        else
        {
            selected = null;
        }

        CheckHotbar();

        if(keyboard.iKey.wasPressedThisFrame || keyboard.tabKey.wasPressedThisFrame)
        {
            inventory.ToggleShowing();
        }
        


    }


    private void CheckHotbar()
    {
        if (keyboard.digit1Key.wasPressedThisFrame)
        {
            HotBarItem = hotbar.checkAtIndex(1);
            if(HotBarItem != null)
            {
                HotbarItemLoad(HotBarItem);
            }
                
                
            Debug.Log(HotBarItem);
        }
        if (keyboard.digit2Key.wasPressedThisFrame)
        {
            HotBarItem = hotbar.checkAtIndex(2);
            if (HotBarItem != null)
            {
                HotbarItemLoad(HotBarItem);
            }
            Debug.Log(HotBarItem);
        }
        if (keyboard.digit3Key.wasPressedThisFrame)
        {
            HotBarItem = hotbar.checkAtIndex(3);
            if (HotBarItem != null)
            {
                HotbarItemLoad(HotBarItem);
            }
            Debug.Log(HotBarItem);
        }
        if (keyboard.digit4Key.wasPressedThisFrame)
        {
            HotBarItem = hotbar.checkAtIndex(4);
            if (HotBarItem != null)
            {
                HotbarItemLoad(HotBarItem);
            }
            Debug.Log(HotBarItem);
        }
        if (keyboard.digit5Key.wasPressedThisFrame)
        {
            HotBarItem = hotbar.checkAtIndex(5);
            if (HotBarItem != null)
            {
                HotbarItemLoad(HotBarItem);
            }
            Debug.Log(HotBarItem);
        }
        if (keyboard.digit6Key.wasPressedThisFrame)
        {
            HotBarItem = hotbar.checkAtIndex(6);
            if (HotBarItem != null)
            {
                HotbarItemLoad(HotBarItem);
            }
            Debug.Log(HotBarItem);
        }
        if (keyboard.digit7Key.wasPressedThisFrame)
        {
            HotBarItem = hotbar.checkAtIndex(7);
            if (HotBarItem != null)
            {
                HotbarItemLoad(HotBarItem);
            }
            Debug.Log(HotBarItem);
        }
    }
    

    private void HotbarItemLoad(GameObject o)
    {
        if (hand.transform.childCount > 0)
        {
            GameObject old = hand.transform.GetChild(0).gameObject;
            Debug.Log(old);
            GameObject theNew = Instantiate<GameObject>(o, old.transform.position, old.transform.rotation, hand.transform);
            Debug.Log(theNew);
            Vector3 newT = old.transform.position;
            
            theNew.transform.position = newT;
            Debug.Log(FindObjectOfType<PlayerController>().tool);
            FindObjectOfType<PlayerController>().tool = theNew.GetComponent<ItemController>();
            
            Destroy(old);
        }
        else
        {
            Vector3 vec = hand.transform.position;

            GameObject theNew = Instantiate<GameObject>(o, hand.transform.position, hand.transform.rotation, hand.transform);
            FindObjectOfType<PlayerController>().tool = theNew.GetComponent<ItemController>();
        }
        
    }
    
    private GameObject SelectByHere(Vector2 vec, string[] findThis = null)
    {
        List<GameObject> foundThese = new List<GameObject>();
        GameObject _object = null;
        Vector2 here = canvas.worldCamera.ScreenToWorldPoint(vec);
        Debug.Log(here);

        Collider2D[] these = Physics2D.OverlapPointAll(here, 1);

        
        if (findThis != null)
        {
            foreach (var o in these)
            {
                foundThese.Add(o.gameObject);
            }
            for (int i = 0; i < findThis.Length; i++)
            {
                foundThese.ForEach(x => {
                    if (x.tag == findThis[i])
                        _object = x;
                });
            }
        }
        else
        {

        }


        return _object;

    }

    
}
