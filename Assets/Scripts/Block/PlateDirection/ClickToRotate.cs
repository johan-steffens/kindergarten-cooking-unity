using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToRotate : MonoBehaviour
{
    public bool playerCanRotate = true;
    public Direction direction = Direction.DOWN; // current direction
    public List<Direction> availableDirections = new List<Direction> { Direction.UP, Direction.LEFT, Direction.DOWN, Direction.RIGHT }; // available directions
    
    void Start()
    {
        SetRotation(direction);
    }

    void Update()
    {
        if (playerCanRotate && Input.GetMouseButtonDown(0))
        {
            CheckClicked();
        }
    }

    void CheckClicked()
    {
        // Cast a ray to see where the user clicked
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction, Mathf.Infinity);

        // If hit, the player has clicked this block's collider
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.gameObject == gameObject)
            {
                int index = availableDirections.IndexOf(direction) + 1;
                if (index == availableDirections.Count)
                {
                    index = 0;
                }

                // Change direction and rotation
                Direction newDirection = availableDirections[index];
                SetRotation(newDirection);
            }
        }
    }

    private void SetRotation(Direction newDirection)
    {
        int zAngle = 0; // Direction.UP
        if(newDirection == Direction.LEFT)
        {
            zAngle = 90;
        } else if(newDirection == Direction.DOWN)
        {
            zAngle = 180;
        } else if(newDirection == Direction.RIGHT)
        {
            zAngle = 270;
        }

        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, zAngle);

        // Set new direction
        direction = newDirection;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlateMovement plate = collision.gameObject.GetComponent<PlateMovement>();
        if (plate != null && ! plate.IsTargetSet())
        {
            Vector3 plateSize = plate.GetComponent<SpriteRenderer>().bounds.size;
            Vector3 target = transform.position;
            target.x += plate.direction == Direction.RIGHT ? plateSize.x / 8f : 0;
            plate.SetTarget(target, direction);
        }
    }

}
