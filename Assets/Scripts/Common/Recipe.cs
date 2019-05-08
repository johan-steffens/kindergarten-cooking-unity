using System.Collections.Generic;

[System.Serializable]
public class Recipe
{

    public string name;
    public List<Ingredient> ingredients = new List<Ingredient>();

    public Recipe() { }

    public Recipe(string name, List<Ingredient> ingredients)
    {
        this.name = name;
        this.ingredients = ingredients;
    }
}