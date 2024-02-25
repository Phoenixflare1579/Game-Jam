using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    //private BoxCollider Ecollider;

    [SerializeField] private int HP;
    [SerializeField] private int EXP;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float attackRange;
    [SerializeField] private int attackDamage;
    [SerializeField] private float speed;
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
        targetStats.HP -= (attackDamage - targetStats.Def);
        if ((attackDamage - targetStats.Def) < 1)
        {
            targetStats.HP -= 1;
        }
    }

    public int getHP()
    {
        return HP;
    }

    public void setHP(int _HP)
    {
        HP = _HP;
        if (HP <= 0)
        {
            target.GetComponent<PlayerStats>().EXP += EXP;
            Destroy(gameObject);
        }
    }

    void OnDrawGizmos()
    {
        if (target != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
        }
    }
}
