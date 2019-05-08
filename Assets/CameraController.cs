using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 20f;
    public Vector2 panBounds;

    private float zPosition;

    void Start()
    {
        zPosition = transform.position.z;   
    }

    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            // Calculate new camera position
            Vector2 position = transform.position;
            position.x += Input.GetAxis("Horizontal") * panSpeed * Time.deltaTime;
            position.y += Input.GetAxis("Vertical") * panSpeed * Time.deltaTime;

            // Set camera position
            Vector3 transformMovement = new Vector3(position.x, position.y, zPosition);
            transformMovement.x = Mathf.Clamp(position.x, -panBounds.x, panBounds.x); // Clamp horizontal bounds
            transformMovement.y = Mathf.Clamp(position.y, -panBounds.y, panBounds.y); // Clamp vertical bounds
            transform.position = transformMovement;
        }
    }
}
