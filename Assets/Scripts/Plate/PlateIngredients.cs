using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateIngredients : MonoBehaviour
{

    public List<Ingredient> ingredients;

    public void AddIngredient(Ingredient ingredient)
    {
        if(ingredients == null)
        {
            ingredients = new List<Ingredient>();
        }
        ingredients.Add(ingredient);
    }

}
