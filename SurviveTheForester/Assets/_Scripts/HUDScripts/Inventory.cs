using System.Collections.Generic;
using UnityEngine;
public class Inventory : MonoBehaviour, IInventory
{
    [field: SerializeField]
    public GameObject inventory;
    [field: SerializeField]
    public List<GameObject> inventorySlots;
    [field: SerializeField]
    public List<GameObject> hotbarSlots;
    protected Renderer renderer;
    protected Renderer rendererSlot;

    bool _showing = false;

    private void Awake()
    {
        renderer = inventory.gameObject.GetComponentInChildren<Renderer>();
        renderer.enabled = false;
        foreach (var gb in inventorySlots)
        {
            Renderer gbrendere = gb.GetComponent<Renderer>();
            gbrendere.enabled = false;
        }
        foreach (var islot in inventorySlots)
        {
            Renderer[] isIteminslot = islot.GetComponentsInChildren<Renderer>();
            for (int i = 0; i < isIteminslot.Length; i++)
            {
                Debug.Log(isIteminslot[i].name);
                isIteminslot[i].enabled = false;
            }

        }

    }
    private void Start()
    {
    }
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.I) && showing == false)
        {
            Debug.Log("vis");
            ShowInventory();
            showing = true;
        }
        else if(Input.GetKeyDown(KeyCode.I) && showing == true)
        {
            Debug.Log("gem");
            HideInventory();
            showing = false;
        }*/
            
    }
    private void ShowInventory()
    {
        
        Debug.Log("Inventoryslots " + GameObject.FindGameObjectsWithTag("InventorySlot").Length);

        renderer.enabled = true;
        foreach (var gb in inventorySlots)
        {
            Renderer gbrendere = gb.GetComponent<Renderer>();
            gbrendere.enabled = true;
        }
        foreach (var islot in inventorySlots)
        {
            Renderer[] isIteminslot = islot.GetComponentsInChildren<Renderer>();
            for (int i = 0; i < isIteminslot.Length; i++)
            {
                //Debug.Log(isIteminslot[i].name);
                isIteminslot[i].enabled = true;
            }
        }
        
    }
    private void HideInventory()
    {
        

        renderer.enabled = false;
        foreach (var gb in inventorySlots)
        {
            Renderer gbrendere = gb.GetComponent<Renderer>();
            gbrendere.enabled = false;

        }
        if (inventorySlots.Count > 0)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("InventorySlot"))
            {
                Renderer renderers = go.GetComponent<Renderer>();
                if (rendererSlot != null)
                {
                    renderers.enabled = false;
                }
            }
        }
        foreach (var islot in inventorySlots)
        {
            Renderer[] isIteminslot = islot.GetComponentsInChildren<Renderer>();
            for (int i = 0; i < isIteminslot.Length; i++)
            {
                //Debug.Log(isIteminslot[i].name);
                isIteminslot[i].enabled = false;
            }
        }
        
    }

    public void ToggleShowing()
    {
        
        _showing = !_showing;
        if (_showing)
        {
            ShowInventory();
        }
        else
        {
            HideInventory();
        }
        
    }

    public bool AddItem(GameObject item)
    {
        bool availableSlots = false;
        foreach (GameObject g in inventorySlots)
        {
            if (g.transform.Find(item.name))
            {
                item.transform.SetParent(g.transform);
                Renderer itemRendere = item.GetComponentInChildren<Renderer>();
                itemRendere.enabled = false;
                item.transform.position = g.transform.position;
                availableSlots = true;
                break;
            }
            else if(g.transform.childCount == 0)
            {
                item.transform.SetParent(g.transform);
                Renderer itemRendere = item.GetComponentInChildren<Renderer>();
                itemRendere.enabled = false;
                item.transform.position = g.transform.position;
                availableSlots = true;
                break;
            }
            else
            {
                availableSlots = false;
            }
        }
        if (_showing)
        {
            HideInventory();
            ShowInventory();
        }
        return availableSlots;
    }

    public bool RemoveItem(GameObject item)
    {
        throw new System.NotImplementedException();
    }

    public bool MoveItem(GameObject item, int newPosition)
    {
        throw new System.NotImplementedException();
    }

    public GameObject SelectItemInHotbar(int itemPosition)
    {
        throw new System.NotImplementedException();
    }
}
