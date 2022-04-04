using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAIBrain : MonoBehaviour, IAgentInput, IBreakable
{
    [field: SerializeField]
    public GameObject Target { get; set; }

    [field: SerializeField]
    public AIState CurrentState { get; private set; }

    [field: SerializeField]
    public UnityEvent<Vector2> OnMovementKeyPressed { get; set; }
    [field: SerializeField]
    public UnityEvent<Vector2> OnPointerPositionChange { get ; set ; }
    public int health = 4;
    public int dmgtaken = 1;


    private void Awake()
    {
        Target = FindObjectOfType<PlayerController>().gameObject;
        //Taget = FindObjectOfType<
    }

    private void Update()
    {
        if (Target == null)
        {
            OnMovementKeyPressed?.Invoke(Vector2.zero);
        }
        
        

    }

    private void FixedUpdate()
    {
        CurrentState.UpdateState();
    }

    public void Attack()
    {
        //OnFireButtunPressed?.Invoke();
    }

    public void Move(Vector2 movementDirection, Vector2 targetPosition)
    {
        OnMovementKeyPressed?.Invoke(movementDirection);
        OnPointerPositionChange?.Invoke(targetPosition);
    }

    internal void ChangeToState(AIState state)
    {
        CurrentState = state;
    }

    public void Break(ITool tool)
    {
        
        if (health > 0 && tool.Name() == "Stick")
        {
            health -= dmgtaken;
        }
        else if((health > 0 && tool.Name() == "HackingTool+"))
        {
            health -= dmgtaken;
            health -= dmgtaken;
            health -= dmgtaken;
        }
        else if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
