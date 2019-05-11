using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageColorChanger : MonoBehaviour
{

    public float speed;

    private Image image;
    private Color targetColor;
    private float timeLeft;

    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        if (timeLeft <= Time.deltaTime)
        {
            // Finished transition
            image.color = targetColor;

            // Start a new transition
            targetColor = new Color(Random.value, Random.value, Random.value);
            timeLeft = 2 / speed;
        }
        else
        {
            // Calculate interpolated color
            image.color = Color.Lerp(image.color, targetColor, Time.deltaTime / timeLeft);

            // Update the timer
            timeLeft -= Time.deltaTime;
        }
    }

}
