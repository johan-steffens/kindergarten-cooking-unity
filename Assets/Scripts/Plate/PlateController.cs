using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlateController : MonoBehaviour
{

    public List<Ingredient> addedIngredients = new List<Ingredient>();
    public Collider2D hoverCollider;
    public Sprite normalSprite;
    public Sprite hoverSprite;
    public Recipe recipe;

    private SpriteRenderer spriteRenderer;
    private RecipeCard card;
    private PlateMovement movement;

    private bool hovering = false;

    void Start()
    {
        movement = GetComponent<PlateMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Check if mouse is hovering over plate
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction, Mathf.Infinity);
        if (! hovering && hits.Where(hit => { return hit.collider == hoverCollider; }).Count() >= 1)
        {
            hovering = true;
            SetSprite(hovering);
        } else if(hovering && hits.Where(hit => { return hit.collider == hoverCollider; }).Count() == 0)
        {
            hovering = false;
            SetSprite(hovering);
        }
    }

    public void NotifyHover(bool hovering)
    {
        SetSprite(hovering);
    }

    private void SetSprite(bool hovering)
    {
        spriteRenderer.sprite = hovering ? hoverSprite : normalSprite;
    }

    public void AddIngredient(Ingredient ingredient)
    {
        addedIngredients.Add(ingredient);
        card.NotifyIngredientsAdded();
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
