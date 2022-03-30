using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class AgentMovement : MonoBehaviour
{
    protected Rigidbody2D rigidbody2D;
    [field: SerializeField]
    public MovementDataSO MovementData { get; set; }
    [field: SerializeField]
    protected float currentVelocity = 3;
    protected Vector2 movementDirection;

    [field: SerializeField]
    public UnityEvent<float> OnVelocityChange { get; set; }
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void MoveAgent(Vector2 movementInput)
    {
        if (movementInput.magnitude > 0)
        {
            if (Vector2.Dot(movementInput.normalized, movementDirection) < 0)
                currentVelocity = 0;
            movementDirection = movementInput.normalized;
        }
        currentVelocity = CalculateSpeed(movementInput);  
    }

    private float CalculateSpeed(Vector2 movementInput)
    {
        if (movementInput.magnitude > 0)
        {
            currentVelocity += MovementData.acceleration * Time.deltaTime;
        }
        else
        {
            currentVelocity -= MovementData.deacceleration;
        }
        return Mathf.Clamp(currentVelocity, 0, MovementData.maxSpeed);

    }
    private void FixedUpdate()
    {
        OnVelocityChange?.Invoke(currentVelocity);
        rigidbody2D.velocity = currentVelocity * movementDirection.normalized;

    }
}
