using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private void Start()
    {
        transform.position = Vector3.zero;
    }

    private void Update()
    {
        MovePlayer();
        ClampHorizontalMovement();
        WrapVerticalMovement();
    }

    private void MovePlayer()
    {
        float moveFactor = moveSpeed * Time.deltaTime;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontalInput,verticalInput,0) * moveFactor);
    }

    private void ClampHorizontalMovement()
    {
        transform.position = new Vector3(transform.position.x, Math.Clamp(transform.position.y, -4,6), 0);
    }

    private void WrapVerticalMovement()
    {
        float boundX = 11.3f;
        
        if (transform.position.x >= boundX)
        {
            transform.position = new Vector3(-boundX, transform.position.y, 0);
        }
        else if (transform.position.x <= -boundX)
        {
            transform.position = new Vector3(boundX, transform.position.y, 0);
        }
    }
}
