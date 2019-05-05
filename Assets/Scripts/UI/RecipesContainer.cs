using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipesContainer : MonoBehaviour
{
    public int paddingTop = 10;
    public int paddingLeft = 10;

    public GameObject prefab;

    private static RecipesContainer instance; // there should be only one instance per scene

    void Start()
    {
        instance = this;
    }

    public static RecipesContainer GetInstance()
    {
        return instance;
    }

    public RecipeCard[] GetRecipeCards()
    {
        return GetComponentsInChildren<RecipeCard>();
    }

    public GameObject AddCard()
    {
        int recipeCount = GetRecipeCards().Length;

        GameObject newCard = Instantiate(prefab);
        newCard.transform.SetParent(gameObject.transform, false);

        ReorderCards();

        return newCard;
    }

    public void ReorderCards()
    {
        for(int i = 0; i < GetRecipeCards().Length; i++)
        {
            RecipeCard card = GetRecipeCards()[i];
            RectTransform transform = card.GetComponent<RectTransform>();
            Vector2 position = transform.anchoredPosition;
            position.x = paddingLeft;
            position.y = -paddingTop - (transform.sizeDelta.y * i + paddingTop * i);
            transform.anchoredPosition = position;
        }
    }

}
