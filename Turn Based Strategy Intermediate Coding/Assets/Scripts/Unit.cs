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
        
        if(leftMouseDown)
        {
            this.targetPosition = MouseWorld.GetPosition();
            this.isMoving = true;
        }

        if(this.isMoving) MoveToTarget();
    }

    private void MoveToTarget()
    {
        if (IsAtTargetPosition()) 
        {
            transform.position = this.targetPosition;
            this.isMoving = false;
            return;
        }
        Vector3 moveDirection = (this.targetPosition - transform.position).normalized;
        transform.position += moveDirection * this.moveSpeed * Time.deltaTime;
    }

    private bool IsAtTargetPosition()
    {
        float stoppingDistance = 0.1f;
        return Vector3.Distance(transform.position, targetPosition) < stoppingDistance;
    }
}
