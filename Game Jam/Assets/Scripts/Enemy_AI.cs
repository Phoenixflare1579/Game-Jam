using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public Rigidbody rb;
    //private BoxCollider Ecollider;
    public float speed = 2;
    public float dectectionRange;
    public Vector3 direction;

    public GameObject target;

    public float attackCooldown = 1;
    public float attackRange = 1;
    public int attackDamage = 5;

    private RaycastHit[] hits;
    private IEnumerator coroutine;

    void Start()
    {
        this.transform.rotation = Quaternion.Euler(90, 0, 0);
        //Ecollider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player");

        coroutine = AttackWait();
        StartCoroutine(coroutine);
    }


    void Update()
    {
        direction = target.transform.position - rb.transform.position;

        rb.velocity = direction.normalized * speed;

    }

    private IEnumerator AttackWait()
    {
        while (true)
        {
            hits = Physics.RaycastAll(transform.position, direction, attackRange);

            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];
                GameObject hitObject = hit.collider.gameObject;

                if (hitObject.tag == "Player")
                {
                    Attack(target);
                }

            }

            yield return new WaitForSeconds(attackCooldown);

    }
    }

    void Attack(GameObject target)
    {
        PlayerStats targetStats = target.GetComponent<PlayerStats>();
        Debug.Log("hit target");
        targetStats.HP -= attackDamage;
    }
}
