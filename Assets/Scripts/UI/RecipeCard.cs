using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeCard : MonoBehaviour
{

    public Sprite basePanelSprite;
    public Sprite hoverPanelSprite;
    public Sprite failedPanelSprite;
    public Sprite completedPanelSprite;

    private Image rootImage;

    private Text txtOrderNumber;
    private Text txtProfit;

    private GameObject failedText;
    private GameObject completedText;
    private GameObject ingredientOne;
    private GameObject ingredientTwo;
    private GameObject ingredientThree;
    private GameObject ingredientFour;
    private GameObject ingredientFive;

    private int orderNumber = 0;
    private Recipe recipe;
    private int price = 0;
    private int profit = 0;

    void Start()
    {
        // Get image elements
        rootImage = GetComponent<Image>();

        // Get text elements
        txtOrderNumber = transform.Find("Order Number Text").GetComponent<Text>();
        txtProfit = transform.Find("Order Profit").GetComponent<Text>();

        // Get advanced elements
        failedText = transform.Find("Failed Text").gameObject;
        completedText = transform.Find("Completed Text").gameObject;
        ingredientOne = transform.Find("Ingredient One").gameObject;
        ingredientTwo = transform.Find("Ingredient Two").gameObject;
        ingredientThree = transform.Find("Ingredient Three").gameObject;
        ingredientFour = transform.Find("Ingredient Four").gameObject;
        ingredientFive = transform.Find("Ingredient Five").gameObject;

        // Set initial state
        ResetState();
    }

    public void ResetState()
    {
        rootImage.sprite = basePanelSprite;
        failedText.SetActive(false);
        completedText.SetActive(false);
    }

    public void SetStateCompleted()
    {
        // Reset to base
        ResetState();

        // Apply changes
        rootImage.sprite = completedPanelSprite;
        completedText.SetActive(true);
    }

    public void SetStateFailed()
    {
        // Reset to base
        ResetState();

        // Apply changes
        rootImage.sprite = failedPanelSprite;
        failedText.SetActive(true);
    }

    public void SetRecipe(Recipe recipe)
    {
        this.recipe = recipe;

        // Process recipe information
        price = 0;
        foreach (Ingredient ingredient in recipe.ingredients)
        {
            price += (int) ingredient;
        }
        profit = price + Mathf.RoundToInt(price * 0.1f);
        txtProfit.text = "$" + profit;
    }

    public void SetOrderNumber(int orderNumber)
    {
        this.orderNumber = orderNumber;
        txtOrderNumber.text = "Order #" + orderNumber;
    }
}
