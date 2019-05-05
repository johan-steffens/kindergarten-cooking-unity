using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToAddIngredient : MonoBehaviour
{

    public Ingredient ingredient;
    public SpriteRenderer debugIndicator;

    private List<PlateIngredients> targets = new List<PlateIngredients>();

    void Update()
    {
        // Debug indicator showing if you can click to add an ingredient to the plate
        if(debugIndicator != null)
        {
            if(targets.Count == 0)
            {
                debugIndicator.color = Color.red;
            } else
            {
                debugIndicator.color = Color.green;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlateIngredients plate = collision.gameObject.GetComponent<PlateIngredients>();
        if (plate != null)
        {
            targets.Add(plate);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        PlateIngredients plate = collision.gameObject.GetComponent<PlateIngredients>();
        if (plate != null)
        {
            targets.Remove(plate);
        }
    }
}
