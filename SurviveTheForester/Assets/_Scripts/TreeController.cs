using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour, IBreakable
{  
    [SerializeField]
    ObjectPool objectPool;
    [SerializeField]
    int health = 10;
    Animator animator;

    bool destroyed = false;

    
    public void Break(ITool tool)
    {
        if (!destroyed && tool != null)
        {
            if (tool.Name() == "HackingItem")
            {
                health -= 1;
                animator.Play("Shake");

            }
            else if (tool.Name() == "HackingItem+")
            {
                health -= 4;
                animator.Play("Shake");
            }
            if (health < 0)
            {
                destroyed = true;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (destroyed)
        {
            GameObject dropThis = Instantiate(objectPool.GetGameObject("wood"), this.gameObject.transform.position, this.gameObject.transform.rotation);
            dropThis.SetActive(true);
            dropThis.name = "wood";
            this.gameObject.SetActive(false);
        }
    }
}
