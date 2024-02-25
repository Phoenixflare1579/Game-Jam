using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearAim : MonoBehaviour
{
    [SerializeField] private float range = 10;
    [SerializeField] private float attackSpeed = 1;
    [SerializeField] private float spearSize = 2;
    [SerializeField] private Collider[] hitColliders;
    [SerializeField] private Collider bestTarget;
    [SerializeField] private Vector3 bestTargetDirection;
    [SerializeField] private float bestTargetAmount;
    [SerializeField] private GameObject weapon;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float projectileSpeed = 5;
    [SerializeField] private int projectileDamage = 20;
    [SerializeField] private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(0, 0, -0.1f);

        weapon = transform.GetChild(0).gameObject;
        weapon.transform.localPosition = new Vector3(0f, 0f, -0.6f);
        weapon.transform.localRotation = Quaternion.Euler(90f, 0f, 45f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > attackSpeed)
        {
            timer = attackSpeed;
        }

        bestTargetAmount = 0;
        bestTarget = null;

        hitColliders = Physics.OverlapSphere(transform.position, range);
        if (hitColliders.Length > 0)
        {
            for (int i = 0; i < hitColliders.Length; i++)
            {
                Collider target = hitColliders[i];
                Vector3 targetDirection = hitColliders[i].transform.position - transform.position;
                RaycastHit[] harpoonHitColliders = Physics.SphereCastAll(transform.position, spearSize / 2, targetDirection, range);

                if (harpoonHitColliders.Length > bestTargetAmount && hitColliders[i].gameObject.tag == "Enemy")
                {
                    bestTarget = hitColliders[i];
                    bestTargetAmount = harpoonHitColliders.Length;
                    bestTargetDirection = -targetDirection;

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

    public float getSpearSize()
    {
        return spearSize;
    }

    public float getRange()
    {
        return range;
    }

    void OnDrawGizmos()
    {
        if (bestTarget != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, range);

            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position - range * bestTargetDirection.normalized);

            float angle = Vector3.SignedAngle(bestTargetDirection, new Vector3(1, 0, 0), Vector3.up) * Mathf.PI / 180;

            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position + new Vector3(spearSize * Mathf.Cos(angle - Mathf.PI / 2), 0, spearSize * Mathf.Sin(angle - Mathf.PI / 2)),
                            transform.position - range * bestTargetDirection.normalized + new Vector3(spearSize * Mathf.Cos(angle - Mathf.PI / 2), 0, spearSize * Mathf.Sin(angle - Mathf.PI / 2)));
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position + new Vector3(spearSize * Mathf.Cos(angle + Mathf.PI / 2), 0, spearSize * Mathf.Sin(angle + Mathf.PI / 2)),
                            transform.position - range * bestTargetDirection.normalized + new Vector3(spearSize * Mathf.Cos(angle + Mathf.PI / 2), 0, spearSize * Mathf.Sin(angle + Mathf.PI / 2)));
        }
    }
}
