using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneSceneController : MonoBehaviour
{
    public GameObject platePrefab;
    public List<Recipe> recipes;

    private int currentOrderNumber = 1;

    private static LevelOneSceneController instance; // there should be only one instance per scene

    void Start()
    {
        instance = this;
    }

    public void NewOrder()
    {
        StartCoroutine(ConfigureNewOrder());
    }

    private IEnumerator ConfigureNewOrder()
    {
        // Generate the recipe
        Recipe recipe = recipes[Random.Range(0, recipes.Count)];

        // Instantiate game objects
        GameObject card = RecipesContainer.GetInstance().AddCard();
        GameObject plate = Instantiate(platePrefab);

        // Wait for objects to instantiate
        yield return new WaitForEndOfFrame();
        
        // Configure plate
        plate.GetComponent<PlateController>().SetCard(card.GetComponent<RecipeCard>());
        plate.GetComponent<PlateController>().SetRecipe(recipe);

        // Configure recipe card
        card.GetComponent<RecipeCard>().SetOrderNumber(currentOrderNumber);
        card.GetComponent<RecipeCard>().SetRecipe(recipe);

        currentOrderNumber++;
    }

}
