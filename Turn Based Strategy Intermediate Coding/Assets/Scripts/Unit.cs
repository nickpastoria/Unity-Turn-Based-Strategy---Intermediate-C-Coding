using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private Animator unitAnimator;
    private bool isMoving = false;
    private Vector3 targetPosition;

    private void Update()
    {
        mouseWalking();
    }

    private void mouseWalking()
    {
        // 0 is left 1 is right
        int mouseButton = 0;
        bool leftMouseDown = Input.GetMouseButtonDown(mouseButton);
        
        if(leftMouseDown)
        {
            this.targetPosition = MouseWorld.GetPosition();
            unitAnimator.SetBool("isWalking", true);
            this.isMoving = true;
        }

        if (IsAtTargetPosition()) 
        {
            // Close any small gap that may exist between the unit and the target position.
            transform.position = this.targetPosition;
            unitAnimator.SetBool("isWalking", false);
            this.isMoving = false;
        }

        if(this.isMoving) MoveToTarget();
    }
    private void MoveToTarget()
    {
        Vector3 moveDirection = (this.targetPosition - transform.position).normalized;
        transform.position += moveDirection * this.moveSpeed * Time.deltaTime;
    }

    private bool IsAtTargetPosition()
    {
        float stoppingDistance = 0.1f;
        return Vector3.Distance(transform.position, targetPosition) < stoppingDistance;
    }
}
