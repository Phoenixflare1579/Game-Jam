using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    //private BoxCollider Ecollider;

    [SerializeField] private float attackCooldown = 1;
    [SerializeField] private float attackRange = 5;
    [SerializeField] private int attackDamage = 5;
    [SerializeField] private float speed = 2;
    [SerializeField] private float dectectionRange;
    [SerializeField] private GameObject target;
    [SerializeField] private Vector3 direction;
    private float distance;
    [SerializeField] private Collider[] hitColliders;
    private IEnumerator coroutine;

    void Start()
    {
        this.transform.rotation = Quaternion.Euler(90, 0, 0);
        //Ecollider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player");
        direction = target.transform.position - rb.transform.position;
        distance = direction.magnitude;

        coroutine = AttackWait();
        StartCoroutine(coroutine);
    }


    void Update()
    {
        direction = target.transform.position - rb.transform.position;
        distance = direction.magnitude;

        if (distance > 1 )
        {
            rb.velocity = direction.normalized * speed;
        }
        else
        {
            rb.velocity = direction.normalized * 0;
        }
    }

    private IEnumerator AttackWait()
    {
        while (true)
        {
            hitColliders = Physics.OverlapSphere(transform.position, attackRange);
            if (hitColliders.Length > 0)
            {
                for (int i = 0; i < hitColliders.Length; i++)
                {
                    if (hitColliders[i].gameObject.tag == "Player")
                    {
                        Attack(hitColliders[i].gameObject);
                    }
                }
            }

            yield return new WaitForSeconds(attackCooldown);

        }
    }

    void Attack(GameObject target)
    {
        PlayerStats targetStats = target.GetComponent<PlayerStats>();
        targetStats.HP -= attackDamage;
    }

    void OnDrawGizmos()
    {
        if (target != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, attackRange);
        }
    }
}
