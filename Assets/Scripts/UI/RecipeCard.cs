using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RecipeCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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

    private bool hovering = false;
    private bool completed = false;
    private bool failed = false;

    private PlateController plate;

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

        // State
        completed = true;
        failed = false;
    }

    public void SetStateFailed()
    {
        // Reset to base
        ResetState();

        // Apply changes
        rootImage.sprite = failedPanelSprite;
        failedText.SetActive(true);
        
        // State
        completed = true;
        failed = true;
    }

    public void SetRecipe(Recipe recipe)
    {
        this.recipe = recipe;

        // Process recipe information
        price = 0;
        foreach (Ingredient ingredient in recipe.ingredients)
        {
            price += ingredient.value;
        }
        profit = price + Mathf.RoundToInt(price * Random.Range(1, 3) / 10f);
        txtProfit.text = "$" + profit;

        // Update ingredients
        UpdateIngredients();
    }

    public void SetOrderNumber(int orderNumber)
    {
        this.orderNumber = orderNumber;
        txtOrderNumber.text = "Order #" + orderNumber;
    }

    public int GetOrderNumber()
    {
        return orderNumber;
    }

    public void SetPlate(PlateController plate)
    {
        this.plate = plate;
    }

    public void NotifyIngredientsAdded()
    {
        UpdateIngredients();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovering = true;
        SetSprite(hovering);
        plate.NotifyHover(hovering);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovering = true;
        SetSprite(false);
        plate.NotifyHover(false);
    }

    public void NotifyHover(bool hovering)
    {
        SetSprite(hovering);
    }

    private void SetSprite(bool hovering)
    {
        rootImage.sprite = hovering ? hoverPanelSprite : basePanelSprite;
    }

    private void UpdateIngredients()
    {
        if (completed || failed)
            return;

        int ingredientCount = recipe.ingredients.Count;
        for (int i = 0; i < ingredientCount; i++)
        {
            if (i == 4 || completed || failed)
                break;

            Ingredient ingredient = recipe.ingredients[i];
            if(i == 0)
            {
                Image image = ingredientOne.transform.Find("Icon One").gameObject.GetComponent<Image>();
                image.sprite = Resources.Load<Sprite>("Icons/" + ingredient.iconName);
                Color imageColor = ingredient.color;

                // Check if ingredient 2 matches
                if (plate.addedIngredients.Count >= 1)
                {
                    // Correct ingredient
                    if (plate.addedIngredients[0] == ingredient)
                    {
                        ingredientOne.GetComponent<Image>().CrossFadeColor(Color.green, 0.4f, false, true);
                        imageColor = new Color(0, 0, 0, 0.7f);
                    }
                    // Otherwise order failed
                    else
                    {
                        ingredientOne.GetComponent<Image>().CrossFadeColor(Color.red, 0.4f, false, true);
                        imageColor = new Color(0, 0, 0, 0.7f);
                        SetStateFailed();
                    }
                }

                image.color = imageColor;
                image.CrossFadeColor(imageColor, 0.4f, false, true);
            }
            else if(i == 1)
            {
                Image image = ingredientTwo.transform.Find("Icon Two").gameObject.GetComponent<Image>();
                image.sprite = Resources.Load<Sprite>("Icons/" + ingredient.iconName);
                Color imageColor = ingredient.color;

                // Check if ingredient 2 matches
                if (plate.addedIngredients.Count >= 2)
                {
                    // Correct ingredient
                    if (plate.addedIngredients[1] == ingredient)
                    {
                        ingredientTwo.GetComponent<Image>().CrossFadeColor(Color.green, 0.4f, false, true);
                        imageColor = new Color(0, 0, 0, 0.7f);
                    }
                    // Otherwise order failed
                    else
                    {
                        ingredientTwo.GetComponent<Image>().CrossFadeColor(Color.red, 0.4f, false, true);
                        imageColor = new Color(0, 0, 0, 0.7f);
                        SetStateFailed();
                    }
                }

                image.color = imageColor;
                image.CrossFadeColor(imageColor, 0.4f, false, true);
            }
            else if (i == 2)
            {
                Image image = ingredientThree.transform.Find("Icon Three").gameObject.GetComponent<Image>();
                image.sprite = Resources.Load<Sprite>("Icons/" + ingredient.iconName);
                Color imageColor = ingredient.color;

                // Check if ingredient 2 matches
                if (plate.addedIngredients.Count >= 3)
                {
                    // Correct ingredient
                    if (plate.addedIngredients[2] == ingredient)
                    {
                        ingredientThree.GetComponent<Image>().CrossFadeColor(Color.green, 0.4f, false, true);
                        imageColor = new Color(0, 0, 0, 0.7f);
                    }
                    // Otherwise order failed
                    else
                    {
                        ingredientThree.GetComponent<Image>().CrossFadeColor(Color.red, 0.4f, false, true);
                        imageColor = new Color(0, 0, 0, 0.7f);
                        SetStateFailed();
                    }
                }

                image.color = imageColor;
                image.CrossFadeColor(imageColor, 0.4f, false, true);
            }
            else if (i == 3)
            {
                Image image = ingredientFour.transform.Find("Icon Four").gameObject.GetComponent<Image>();
                image.sprite = Resources.Load<Sprite>("Icons/" + ingredient.iconName);
                Color imageColor = ingredient.color;

                // Check if ingredient 2 matches
                if (plate.addedIngredients.Count >= 4)
                {
                    // Correct ingredient
                    if (plate.addedIngredients[3] == ingredient)
                    {
                        ingredientFour.GetComponent<Image>().CrossFadeColor(Color.green, 0.4f, false, true);
                        imageColor = new Color(0, 0, 0, 0.7f);
                    }
                    // Otherwise order failed
                    else
                    {
                        ingredientFour.GetComponent<Image>().CrossFadeColor(Color.red, 0.4f, false, true);
                        imageColor = new Color(0, 0, 0, 0.7f);
                        SetStateFailed();
                    }
                }

                image.color = imageColor;
                image.CrossFadeColor(imageColor, 0.4f, false, true);
            }
            else if (i == 4)
            {
                Image image = ingredientFive.transform.Find("Icon Five").gameObject.GetComponent<Image>();
                image.sprite = Resources.Load<Sprite>("Icons/" + ingredient.iconName);
                Color imageColor = ingredient.color;

                // Check if ingredient 2 matches
                if (plate.addedIngredients.Count >= 5)
                {
                    // Correct ingredient
                    if (plate.addedIngredients[4] == ingredient)
                    {
                        ingredientFive.GetComponent<Image>().CrossFadeColor(Color.green, 0.4f, false, true);
                        imageColor = new Color(0, 0, 0, 0.7f); 
                    }
                    // Otherwise order failed
                    else
                    {
                        ingredientFive.GetComponent<Image>().CrossFadeColor(Color.red, 0.4f, false, true);
                        imageColor = new Color(0, 0, 0, 0.7f);
                        SetStateFailed();
                    }
                }

                image.CrossFadeColor(imageColor, 0.4f, false, true);
            }
        }

        for(int i = 4; i >= ingredientCount; i--)
        {
            if (i == 0)
            {
                ingredientOne.SetActive(false);
            }
            else if (i == 1)
            {
                ingredientTwo.SetActive(false);
            }
            else if (i == 2)
            {
                ingredientThree.SetActive(false);
            }
            else if (i == 3)
            {
                ingredientFour.SetActive(false);
            }
            else if (i == 4)
            {
                ingredientFive.SetActive(false);
            }
        }

        if (CheckOrderComplete())
        {
            SetStateCompleted();
        }
    }

    private bool CheckOrderComplete()
    {
        if(recipe.ingredients.SequenceEqual(plate.addedIngredients))
        {
            return true;
        }
        return false;
    }

    public void NotifyCompleted()
    {
        if(failed || (! failed && ! completed))
        {
            profit = 0;
        }
        BaseLevelSceneController.GetInstance().NotifyPlateCompleted(profit);
    }

}
