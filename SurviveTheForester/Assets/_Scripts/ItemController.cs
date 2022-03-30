using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour, ITool
{
    public string name;

    public string Name()
    {
        return name;
    }

}
