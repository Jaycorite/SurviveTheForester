using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowChar : MonoBehaviour
{

    public GameObject FollowThis;
    Transform Me;
    // Start is called before the first frame update
    void Start()
    {
        Me = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = FollowThis.transform.localPosition;
        newPosition.z = -10;
        Me.position = newPosition;
        
    }
}
