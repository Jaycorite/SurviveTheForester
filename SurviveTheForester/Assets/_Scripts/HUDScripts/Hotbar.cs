using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hotbar : MonoBehaviour
{
    public Sprite HotBarSlotImage;
    public List<GameObject> Slots;
    int SelectedSlot;

    // Start is called before the first frame update
    void Start()
    {
        LoadHotBar();
        SelectedSlot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int CheckForItems(List<GameObject> os)
    {
        int foundAt = -1;
        foreach(var o in os)
        {
            //if (o.tag) { }
        }


        return foundAt;
    }

    public GameObject? checkAtIndex(int i)
    {
        i--;
        GameObject foundThis = null;
        Debug.Log(Slots[i].transform.childCount);

        if (Slots[i].transform.childCount > 0)
        {
            foundThis = Slots[i].transform.GetChild(0).gameObject;
        }
        Debug.Log(foundThis);
        return foundThis;
    }

    

    private void LoadHotBar()
    {
        float offX = 200, offY = 0, offChange = 100;

        for (int i = 0; i < 7; i++)
        {
            GameObject o = new GameObject("Hotbar Slot" + i);
            o.AddComponent<RectTransform>();
            o.AddComponent<CanvasRenderer>();
            o.AddComponent<BoxCollider2D>();
            //img.sprite = InventorySlotImage;


            o.tag = "Hotbar";

            o.transform.SetParent(this.transform);
            o.transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(this.transform.position.x + (offX + (offChange * i)), this.transform.position.y + (offY));

            RectTransform rect = o.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(1, 1);

            o.AddComponent<Image>();
            o.GetComponent<Image>().sprite = HotBarSlotImage;
            Color color = new Color(0.9f, 0.3f, 0.3f);
            o.GetComponent<Image>().color = color;
            o.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(0.8f, 0.8f);
            o.GetComponent<Image>().rectTransform.anchoredPosition = new Vector2(-498f + (offX + (offChange * i)), 0 + (offY * 3));
            Slots.Add(o);
        }
    }
}
