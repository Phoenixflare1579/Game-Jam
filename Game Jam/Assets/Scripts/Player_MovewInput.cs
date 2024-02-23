using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_MovewInput : MonoBehaviour
{
    public PlayerInput MyInput;
    public InputActionAsset MyMap;
    public Rigidbody rb;
    public float speed;
    public Vector2 lastDirection;

    void Start()
    {
        MyInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();

        if (MyInput != null)
        {
            MyMap = MyInput.actions;
        }
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
        }
    }

    void Update()
    {
        rb.velocity = new Vector3(lastDirection.x, 0, lastDirection.y).normalized * speed;
    }

    public void Move(InputAction.CallbackContext c)
    {
        if (c.performed)
        {
            lastDirection = c.ReadValue<Vector2>();
        }
        else if (c.canceled)
        {
            lastDirection = Vector2.zero;
        }
    }
}
