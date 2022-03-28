using System.Collections.Generic;
using UnityEngine;
public class Inventory : MonoBehaviour
{
    public Transform transinv;
    //public Transform transhot;
    public GameObject followthis;
    public float followinvx;
    public float followinvy;
    public float followhotx;
    public float followhoty;
    [field: SerializeField]
    public GameObject inventory;
    [field: SerializeField]
    public List<GameObject> inventorySlots;
    [field: SerializeField]
    public List<GameObject> hotbarSlots;
    protected Renderer renderer;
    protected Renderer rendererSlot;
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

        transinv = GetComponent<Transform>();
    }
    void Update()
    {
        transinv.localPosition = new Vector3(followthis.transform.localPosition.x + followinvx, followthis.transform.localPosition.y - followinvy);
       
        ShowInventory();
        HideInventory();
    }
    private void ShowInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("vis");
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
    }
    private void HideInventory()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("gem");

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
    }
}
