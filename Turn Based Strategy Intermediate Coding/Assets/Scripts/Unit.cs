using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float turnSpeed = 180f;
    [SerializeField] private Animator unitAnimator;
    private bool isMoving = false;
    private Vector3 targetPosition;

    private void Awake() {
        this.targetPosition = transform.position;
    }

    private void Update()
    {
        mouseWalking();
    }

    public void setWalkTarget(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
        unitAnimator.SetBool("isWalking", true);
        this.isMoving = true;
    }

    private void mouseWalking()
    {
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
        transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * turnSpeed);
        transform.position += moveDirection * this.moveSpeed * Time.deltaTime;
    }

    private bool IsAtTargetPosition()
    {
        float stoppingDistance = 0.1f;
        return Vector3.Distance(transform.position, targetPosition) < stoppingDistance;
    }
}
