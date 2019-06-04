using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseLevelSceneController : MonoBehaviour
{
    [Header("Required Prefabs")]
    public GameObject platePrefab;
    public Text salesAmountText;
    public Text expensesAmountText;
    public Text profitAmountText;

    [Header("Order Creation")]
    public int maxOrders = 5;
    public float orderSpawnFrequency = 1;
    public float plateSpeed = 5;
    [Tooltip("Vector2 coordinates for where in the scene plates can be spawned.")]
    public List<Vector2> spawnPositions;

    protected List<Recipe> recipes;

    private int salesAmount = 0;
    private int expensesAmount = 0;
    private int profitAmount = 0;

    private int currentlyOpenOrders = 0;
    private int currentOrderNumber = 1;

    private bool levelRunning = false;

    private static BaseLevelSceneController instance; // there should be only one instance per scene

    protected void Start()
    {
        instance = this;
        levelRunning = true;
        StartCoroutine(OrderCreator());
    }

    public static BaseLevelSceneController GetInstance()
    {
        return instance;
    }

    public void NewOrder()
    {
        StartCoroutine(ConfigureNewOrder());
    }

    public void NotifyPlateCompleted(int profit)
    {
        salesAmount += profit;
        UpdateAmounts();
        currentlyOpenOrders--;
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

    private IEnumerator OrderCreator()
    {
        // Wait for all objects to initialise before running
        yield return new WaitForEndOfFrame();

        // While the counter is still counting down
        while(levelRunning)
        {
            if (currentlyOpenOrders < maxOrders)
            {
                int chance = Random.Range(0, 10);
                if (chance <= 6)
                {
                    StartCoroutine(ConfigureNewOrder());
                }
            }

            yield return new WaitForSeconds(orderSpawnFrequency);
        }
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
        plate.GetComponent<PlateMovement>().SetSpeed(plateSpeed);

        // Configure recipe card
        card.GetComponent<RecipeCard>().SetOrderNumber(currentOrderNumber);
        card.GetComponent<RecipeCard>().SetPlate(plate.GetComponent<PlateController>());
        card.GetComponent<RecipeCard>().SetRecipe(recipe);

        currentOrderNumber++;
        currentlyOpenOrders++;
    }
}
