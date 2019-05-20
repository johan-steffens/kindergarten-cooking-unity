using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelOneSceneController : BaseLevelSceneController
{

    protected new void Start()
    {
        base.Start();
        recipes = new List<Recipe>
        {
            new Recipe("Mud Pie", new List<Ingredient>{
                Ingredient.MUD, Ingredient.STICKS, Ingredient.MUD
            }),
            new Recipe("Flowerbed Burger", new List<Ingredient>{
                Ingredient.STICKS, Ingredient.MUD, Ingredient.STICKS
            }),
            new Recipe("Garden Salad", new List<Ingredient>{
                Ingredient.MUD, Ingredient.STICKS
            }),
            new Recipe("Garden Salad", new List<Ingredient>{
                Ingredient.STICKS, Ingredient.MUD
            }),
        };
    }


}
