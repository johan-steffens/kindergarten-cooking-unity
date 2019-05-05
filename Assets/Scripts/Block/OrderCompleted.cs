using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderCompleted : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlateController plate = collision.GetComponent<PlateController>();
        if(plate != null)
        {
            plate.CompleteOrder();
        }
    }

}
