using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRb = null;
    [SerializeField] private float moveRate = 1f;

    private void OnMouseEnter()
    {
        if (Mouse.current.leftButton.isPressed) { return; }

        Move(Mouse.current.position.ReadValue());
    }

    private void OnMouseExit()
    {
        StopMove();
    }

    private void StopMove()
    {
        playerRb.velocity = Vector2.zero;
    }

    private void Move(Vector2 mouseTouch)
    {
        Vector2 mouseTouchWorld = Camera.main.ScreenToWorldPoint(mouseTouch);

        Vector2 moveAmount = (Vector2)transform.position - mouseTouchWorld;

        playerRb.velocity = moveAmount * moveRate;

        Debug.Log($"x: {moveAmount.x}, y: {moveAmount.y}");
    }

}
