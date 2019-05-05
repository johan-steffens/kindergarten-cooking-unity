using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour
{

    public List<Ingredient> addedIngredients;

    public Recipe recipe;
    private RecipeCard card;

    private PlateMovement movement;

    void Start()
    {
        movement = GetComponent<PlateMovement>();
    }

    public void AddIngredient(Ingredient ingredient)
    {
        if(addedIngredients == null)
        {
            addedIngredients = new List<Ingredient>();
        }
        addedIngredients.Add(ingredient);
    }

    public void SetCard(RecipeCard card)
    {
        this.card = card;
    }

    public void CompleteOrder()
    {
        StartCoroutine(DestroyOrder());
    }

    private IEnumerator DestroyOrder()
    {
        Destroy(card.gameObject);
        yield return new WaitForSeconds(0.1f);
        RecipesContainer.GetInstance().ReorderCards();
        Destroy(gameObject);
    }
     
    public void SetRecipe(Recipe recipe)
    {
        this.recipe = recipe;
    }
}
