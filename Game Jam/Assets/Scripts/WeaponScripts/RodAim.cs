using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodAim : MonoBehaviour
{
    [SerializeField] private float range = 10;
    [SerializeField] private float attackSpeed = 1;
    [SerializeField] private Collider[] hitColliders;
    [SerializeField] private Collider bestTarget;
    [SerializeField] private Vector3 bestTargetDirection;
    [SerializeField] private float bestTargetDistance;
    [SerializeField] private GameObject weapon;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float projectileSpeed = 2;
    [SerializeField] private int projectileDamage = 2;
    [SerializeField] private float timer = 0f;

    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {

        transform.localPosition = new Vector3(0, 0, -0.1f);

        weapon = transform.GetChild(0).gameObject;
        weapon.transform.localPosition = new Vector3(0f, 0f, -0.6f);
        weapon.transform.localRotation = Quaternion.Euler(90f, 0f, 45f);

        //coroutine = AttackWait();
        //StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > attackSpeed)
        {
            timer = attackSpeed;
        }

        bestTargetDistance = range;
        bestTarget = null;
        hitColliders = Physics.OverlapSphere(transform.position, range);
        if (hitColliders.Length > 0)
        {
            for (int i = 0; i < hitColliders.Length; i++)
            {
                float targetDistance = (transform.position - hitColliders[i].transform.position).magnitude;
                if (targetDistance < bestTargetDistance && hitColliders[i].gameObject.tag == "Enemy")
                {
                    bestTarget = hitColliders[i];
                    bestTargetDirection = transform.position - hitColliders[i].transform.position;
                    bestTargetDistance = (transform.position - bestTarget.transform.position).magnitude;

                    if (timer >= attackSpeed)
                    {
                        Instantiate(projectile, transform.position, Quaternion.identity);
                        timer = 0;
                    }
                }
            }


            if (bestTargetDirection.x < 0)
            {
                weapon.transform.localRotation = Quaternion.Euler(90f, 0f, 45f);
                weapon.GetComponent<SpriteRenderer>().flipY = true;
            }
            else
            {
                weapon.transform.localRotation = Quaternion.Euler(90f, 0f, 135f);
                weapon.GetComponent<SpriteRenderer>().flipY = false;
            }
        }

        transform.rotation = Quaternion.LookRotation(bestTargetDirection);
    }

    //private IEnumerator AttackWait()
    //{
    //    while (true)
    //    {
    //        Instantiate(projectile, transform.position, Quaternion.identity);

    //        yield return new WaitForSeconds(attackSpeed);
    //    }
    //}

    public Vector3 getBestTargetDirection()
    {
        return bestTargetDirection;
    }

    public float getProjectileSpeed()
    {
        return projectileSpeed;
    }

    public int getAttackDamage()
    {
        return projectileDamage;
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
        if (bestTarget != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, bestTarget.transform.position);
        }
    }
}
