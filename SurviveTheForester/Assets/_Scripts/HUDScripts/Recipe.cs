using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour, IRecipe
{
    [field: SerializeField]
    public List<GameObject> _recipe;

    public GameObject _item;
    public string description;


    private void Start()
    {
    }

    
    public List<GameObject> IngredientsList()
    {
        return _recipe;
    }

    public GameObject Item(List<GameObject> Ingredients)
    {
        bool RightIngredients = false;
        foreach (var o in _recipe)
        {
            /*GameObject found = Ingredients.Find(x =>
            {
                if(x.name == o.name)
                {
                    Ingredients.Remove(x);
                    return x;
                }
            });*/

            if (Ingredients.Find(x => x.name == o.name))
            {
                RightIngredients = true;
            }
            else
            {
                RightIngredients = false;
            }
        }

        if (RightIngredients)
            return _item;
        else
            return null;
    }

}