using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateMovement : MonoBehaviour
{
    public float movementSpeed = 1f;
    public Direction direction = Direction.DOWN;

    private Vector3 target = Vector3.negativeInfinity;
    private Direction targetDirection = Direction.DOWN;
    private bool targetSet = false;
    
    void Update()
    {
        Vector3 movement = Vector3.zero;
        bool crossesTarget = false;

        if (direction == Direction.UP)
        {
            movement.y = 0.01f * movementSpeed;
            if (target != Vector3.negativeInfinity && target.y >= transform.position.y && target.y <= (transform.position.y + movement.y))
            {
                movement.y = transform.position.y - target.y;
                crossesTarget = true;
            }
        }
        else if(direction == Direction.LEFT)
        {
            movement.x = -0.01f * movementSpeed;
            if (target != Vector3.negativeInfinity && target.x <= transform.position.x && target.x >= (transform.position.x + movement.x))
            {
                movement.x = target.x - transform.position.x;
                crossesTarget = true;
            }
        }
        else if (direction == Direction.DOWN)
        {
            movement.y = -0.01f * movementSpeed;
            if (target != Vector3.negativeInfinity && target.y <= transform.position.y && target.y >= (transform.position.y + movement.y))
            {
                movement.y = target.y - transform.position.y;
                crossesTarget = true;
            }
        }
        else if (direction == Direction.RIGHT)
        {
            movement.x = 0.01f * movementSpeed;
            if (target != Vector3.negativeInfinity && target.x >= transform.position.x && target.x <= (transform.position.x + movement.x))
            {
                movement.x = transform.position.x - target.x;
                crossesTarget = true;
            }
        }

        transform.position += movement;
        if (crossesTarget)
        {
            crossesTarget = false;
            direction = targetDirection;
            target = Vector3.negativeInfinity;
            targetSet = false;
        }
    }

    public void SetTarget(Vector3 targetPosition, Direction targetDirection)
    {
        this.target = targetPosition;
        this.targetDirection = targetDirection;
        this.targetSet = true;        
    }

    public bool IsTargetSet()
    {
        return targetSet;
    }
}
