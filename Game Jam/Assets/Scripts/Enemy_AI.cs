using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public Rigidbody rb;
    private BoxCollider Ecollider;
    public float speed = 2;
    public float dectectionRange;
    public Vector3 direction;

    public GameObject target;

    void Start()
    {
        this.transform.rotation = Quaternion.Euler(90, 0, 0);
        Ecollider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        direction = target.transform.position - rb.transform.position;

        rb.velocity = direction.normalized * speed;

        if (Physics.CheckSphere(transform.position, 2))
        {
            Attack(target);
        }
    }

    void Attack(GameObject target)
    {
        Debug.Log("hit target");
    }
}
