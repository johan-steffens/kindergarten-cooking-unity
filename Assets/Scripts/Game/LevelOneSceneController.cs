using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneSceneController : MonoBehaviour
{
    public GameObject platePrefab;

    private static LevelOneSceneController instance; // there should be only one instance per scene

    void Start()
    {
        instance = this;
    }

    public void NewOrder()
    {
        GameObject card = RecipesContainer.GetInstance().AddCard();
        GameObject plate = Instantiate(platePrefab);
        plate.GetComponent<PlateController>().SetCard(card.GetComponent<RecipeCard>());
    }

}
