using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventory
{
    public bool AddItem(GameObject item);
    public bool RemoveItem(GameObject item);
    public bool MoveItem(GameObject item, int newPosition);
    public GameObject SelectItemInHotbar(int itemPosition);
    public void ToggleShowing();

}