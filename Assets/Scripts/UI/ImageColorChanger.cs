using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageColorChanger : MonoBehaviour
{

    public float speed;

    private Image image;
    private Color originColor;
    private Color targetColor;
    private float timeLeft = 0;

    void Start()
    {
        image = GetComponent<Image>();
        originColor = new Color(Random.Range(25, 100) / 100f, Random.Range(25, 100) / 100f, Random.Range(25, 100) / 100f);
        targetColor = new Color(Random.Range(25, 100) / 100f, Random.Range(25, 100) / 100f, Random.Range(25, 100) / 100f);
    }

    void Update()
    {
        if (timeLeft <= 0)
        {
            // Finished transition
            image.color = targetColor;

            // Start a new transition
            originColor = targetColor;
            targetColor = new Color(Random.Range(25, 100) / 100f, Random.Range(25, 100) / 100f, Random.Range(25, 100) / 100f);
            timeLeft = 2 / speed;
        }
        else
        {
            // Calculate interpolated color
            image.color = Color.Lerp(originColor, targetColor, 2 / speed - timeLeft);

            // Update the timer
            timeLeft -= Time.deltaTime;
        }
    }

}
