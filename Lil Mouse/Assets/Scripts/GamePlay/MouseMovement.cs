using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.UIElements;

public enum MouseState
{
    Moving,
    Idle
}



public class MouseMovement : MonoBehaviour
{
    [Header("Chracteristics")]
    [SerializeField] private float speed = 2.5f;
    [SerializeField] private float rotationSpeed = 2.5f;
    private Vector3 moveAxis;
    private MouseState mouseState;
    
    private void Start() 
    {
        moveAxis = new Vector3(0,0,0);
        mouseState = MouseState.Idle;
    }

    public void Move()
    {
        //characterController.Move(moveAxis * speed);
        transform.Translate(moveAxis * speed, Space.World);
        Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, moveAxis);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, rotationSpeed);
    }

    private void FixedUpdate()
    {
        if(mouseState == MouseState.Moving)
        Move();
    }

    public void MoveOnEvent(Vector3 movePos)
    {
        if(movePos == Vector3.zero)
        {
            mouseState = MouseState.Idle;
            return;
        }

        mouseState = MouseState.Moving;
        movePos.Normalize();
        moveAxis = movePos;
    }
}
