using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class akInputController : MonoBehaviour
{
    [Header("Character Input Values")]
    public Vector2 move;
    public AnalyticsManager count;

    void Start(){
        
    }

    public void OnMove(InputValue value)
    {
        
        Console.WriteLine("I am here you bet!!");
        count = new AnalyticsManager();
        MoveInput(value.Get<Vector2>());
        count.userStartFunction();
    }

    public void MoveInput(Vector2 newMoveDirection)
    {
        move = newMoveDirection;
    }
}
