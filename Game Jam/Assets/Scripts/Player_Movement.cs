using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float playerSpeed;
    public Rigidbody2D playerRb2D;
    private Vector2 movementInput;
    void Start()
    {
        
    }

    void Update()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        movementInput.Normalize();

        playerRb2D.velocity = movementInput * playerSpeed;
    }
}
