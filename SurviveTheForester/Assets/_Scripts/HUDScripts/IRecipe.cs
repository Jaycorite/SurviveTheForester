using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRecipe
{
    List<GameObject> IngredientsList();
    GameObject Item(List<GameObject> IngredientsList);
}
