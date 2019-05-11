using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickedGraphics : MonoBehaviour
{

    public Sprite normalSprite;
    public Sprite clickedSprite;

    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }

    public void OnMouseDown()
    {
        image.sprite = clickedSprite;
    }

    public void OnMouseUp()
    {
        image.sprite = normalSprite;
    }

}
