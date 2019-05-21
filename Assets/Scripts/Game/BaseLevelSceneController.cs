using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseLevelSceneController : MonoBehaviour
{
    public GameObject platePrefab;

    public Text salesAmountText;
    public Text expensesAmountText;
    public Text profitAmountText;

    public List<Vector2> spawnPositions;

    private int salesAmount = 0;
    private int expensesAmount = 0;
    private int profitAmount = 0;

    protected List<Recipe> recipes;

    private int currentOrderNumber = 1;

    private static BaseLevelSceneController instance; // there should be only one instance per scene

    protected void Start()
    {
        instance = this;
    }

    public static BaseLevelSceneController GetInstance()
    {
        return instance;
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
        plate.transform.position = spawnPositions[Random.Range(0, spawnPositions.Count)];
        plate.GetComponent<PlateController>().SetCard(card.GetComponent<RecipeCard>());
        plate.GetComponent<PlateController>().SetRecipe(recipe);

        // Configure recipe card
        card.GetComponent<RecipeCard>().SetOrderNumber(currentOrderNumber);
        card.GetComponent<RecipeCard>().SetPlate(plate.GetComponent<PlateController>());
        card.GetComponent<RecipeCard>().SetRecipe(recipe);

        currentOrderNumber++;
    }

    public void NotifyPlateCompleted(int profit)
    {
        salesAmount += profit;
        UpdateAmounts();
    }

    public void NotifyExpenseAdded(Ingredient ingredient)
    {
        expensesAmount += ingredient.value;
        UpdateAmounts();
    }

    private void UpdateAmounts()
    {
        // Update profit amount
        profitAmount = salesAmount - expensesAmount;

        // Update the UI
        salesAmountText.text = "$" + salesAmount;
        expensesAmountText.text = "$" + expensesAmount;
        profitAmountText.text = "$" + profitAmount;
    }
}
