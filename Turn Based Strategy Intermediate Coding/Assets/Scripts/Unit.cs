using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    private bool isMoving = false;
    private Vector3 targetPosition;

    private void Update()
    {
        bool leftMouseDown = Input.GetMouseButtonDown(0);
        Move();
        if(leftMouseDown)
        {
            targetPosition = MouseWorld.GetPosition();
            isMoving = true;
        }
    }

    private void Move()
    {
        if (IsAtTargetPosition() && isMoving) 
        {
            transform.position = targetPosition;
            isMoving = false;
            return;
        }
        Vector3 moveDirection = (targetPosition - transform.position).normalized;
        transform.position += moveDirection * this.moveSpeed * Time.deltaTime;
    }

    private bool IsAtTargetPosition()
    {
        float stoppingDistance = 0.1f;
        return Vector3.Distance(transform.position, targetPosition) < stoppingDistance;
    }
}
