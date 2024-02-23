using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public Rigidbody rb;
    private BoxCollider collider;
    public float speed = 2;
    public float dectectionRange;
    public Vector3 direction;

    public GameObject target;

    void Start()
    {
        collider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player");
        //Rigidbody targetRb = target.GetComponent<Rigidbody>();
    }


    void Update()
    {
        direction = target.transform.position - rb.transform.position;

        rb.velocity = direction.normalized * speed;
    }
}
