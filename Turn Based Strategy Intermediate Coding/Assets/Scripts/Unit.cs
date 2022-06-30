using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private Vector3 targetPosition;
    private bool isMoving = false;

    private void Update()
    {
        Move();

        if(Input.GetKeyDown(KeyCode.T)) 
        {
            SetMoveTarget(new Vector3(4, 0, 4));
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

    private void SetMoveTarget(Vector3 targetPosition) 
    {
        this.targetPosition = targetPosition;
        isMoving = true;
    }

    private bool IsAtTargetPosition()
    {
        float stoppingDistance = 0.1f;
        return Vector3.Distance(transform.position, targetPosition) < stoppingDistance;
    }
}
