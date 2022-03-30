using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeBook : MonoBehaviour
{
    public List<Recipe> Recipes = new List<Recipe>();
    // Start is called before the first frame update
    void Start()

    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Recipe rec= transform.GetChild(i).GetComponent<Recipe>();
            Recipes.Add(rec);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    

}



