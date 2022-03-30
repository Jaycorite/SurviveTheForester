using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InventoryUI : MonoBehaviour, IInventory
{
    public ObjectPool pool;
    public List<GameObject> Items;
    List<GameObject> Slots;

    private bool _showing = true;

    public EventSystem eventSystem;


    public Sprite InventorySlotImage;
    




    // Start is called before the first frame update
    void Start()
    {
        Sprite InventorySlot = Resources.Load<Sprite>("");
        float offX = 200, offY = -100, offChange = 100;

        Items = new List<GameObject>();
        Slots = new List<GameObject>();
        pool.objects.ForEach(o => Items.Add(o));
        int slotCounter = 1;

        for (int rows = 0; rows < 4; rows++)
        {
            for (int i = 0; i < 7; i++)
            {
                GameObject o = new GameObject("Inventory Slot " + slotCounter);
                o.AddComponent<RectTransform>();
                o.AddComponent<CanvasRenderer>();
                o.AddComponent<BoxCollider2D>();
                //img.sprite = InventorySlotImage;


                o.tag = "InventorySlot";

                o.transform.SetParent(this.transform);
                o.transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(this.transform.position.x + (offX + (offChange * i)), this.transform.position.y + (offY));

                RectTransform rect = o.GetComponent<RectTransform>();
                rect.sizeDelta = new Vector2(1, 1);

                o.AddComponent<Image>();
                o.GetComponent<Image>().sprite = InventorySlotImage;
                o.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(0.8f, 0.8f);
                o.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(-498f + (offX + (offChange * i)), 150f + (offY * rows));
                Slots.Add(o);
                slotCounter++;
            }
        }
        ToggleShowing();


        /*int ii = 0;
        Items.ForEach(g =>
        {
            
            GameObject g1 = Instantiate(g, Slots[ii].transform);
            g1.GetComponent<Renderer>().sortingOrder = 22;
            g1.transform.position = Slots[ii].transform.position;
            ii++;
        });*/

    }

    // Update is called once per frame
    void Update()
    {
    }
    public bool AddItem(GameObject item)
    {
        bool availableSlots = false;
        foreach (GameObject g in Slots)
        {
            if (g.transform.Find(item.name))
            {
                item.transform.SetParent(g.transform);
                Renderer itemRendere = item.GetComponentInChildren<Renderer>();
                itemRendere.enabled = true;
                item.transform.position = g.transform.position;
                itemRendere.sortingOrder = 22;
                availableSlots = true;
                break;
            }
            else if (g.transform.childCount == 0)
            {
                item.transform.SetParent(g.transform);
                Renderer itemRendere = item.GetComponentInChildren<Renderer>();
                //itemRendere.enabled = false;
                item.transform.position = g.transform.position;
                itemRendere.sortingOrder = 22;
                availableSlots = true;
                break;
            }
            else
            {
                availableSlots = false;
            }
        }
        return availableSlots;
    }

    public List<GameObject> RequestItems(Dictionary<GameObject, int> obejcts)
    {
        List<GameObject> removeThese = new List<GameObject>();
        foreach(var o in obejcts)
        {
            foreach (var slot in Slots)
            {
                Transform transform = slot.transform.Find(o.Key.name);
                
                if (transform != null)
                {
                    if(slot.transform.childCount > o.Value)
                    {
                        for (int i = 0; i < o.Value; i++)
                        {
                            GameObject _o = slot.transform.GetChild(i).gameObject;
                            removeThese.Add(_o);
                            Slots.Remove(_o);
                        }
                    }
                }
            }
        }
        return removeThese;
    }
    public List<GameObject> RequestItems(List<GameObject> obejcts)
    {
        List<GameObject> removeThese = new List<GameObject>();
        foreach (var o in obejcts)
        {
            foreach (var slot in Slots)
            {
                Transform transform = slot.transform.Find(o.name);

                if (transform != null)
                {
                    removeThese.Add(transform.gameObject);
                    
                    transform.parent = transform.root;
                    transform.gameObject.SetActive(false);
                }

            }
        }
        foreach(var o in removeThese)
        {
            obejcts.Remove(o);
            
        }

        return removeThese;
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

    void ShowInventory()
    {
        gameObject.SetActive(true);
    }
    void HideInventory()
    {
        gameObject.SetActive(false);

    }
}
