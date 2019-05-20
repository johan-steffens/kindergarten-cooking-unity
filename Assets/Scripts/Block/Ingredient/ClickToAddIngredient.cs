using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToAddIngredient : MonoBehaviour
{

    protected Ingredient ingredient;
    public SpriteRenderer debugIndicator;

    private List<PlateController> targets = new List<PlateController>();

    void Update()
    {
        // Handle player click events
        if (Input.GetMouseButtonDown(0))
        {
            CheckClicked();
        }

        // Debug indicator showing if you can click to add an ingredient to the plate
        if (debugIndicator != null)
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

    void CheckClicked()
    {
        // Cast a ray to see where the user clicked
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction, Mathf.Infinity);

        // If hit, the player has clicked this block's collider
        foreach(RaycastHit2D hit in hits)
        {
            if (hit.collider.gameObject == gameObject)
            {
                // Add ingredient to all current targets
                foreach (PlateController plate in targets)
                {
                    plate.AddIngredient(ingredient);
                    BaseLevelSceneController.GetInstance().NotifyExpenseAdded(ingredient);
                }
            }
        } 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlateController plate = collision.gameObject.GetComponent<PlateController>();
        if (plate != null)
        {
            targets.Add(plate);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        PlateController plate = collision.gameObject.GetComponent<PlateController>();
        if (plate != null)
        {
            targets.Remove(plate);
        }
    }
}
