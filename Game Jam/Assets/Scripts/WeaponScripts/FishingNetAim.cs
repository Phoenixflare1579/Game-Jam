using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingNetAim : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float fishingNetSize;
    [SerializeField] private Collider[] hitColliders;
    [SerializeField] private Collider bestTarget;
    [SerializeField] private Vector3 bestTargetDirection;
    [SerializeField] private float bestTargetAmount;
    [SerializeField] private GameObject weapon;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float projectileSpeed = 2;
    [SerializeField] private int projectileDamage = 2;
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
                Collider[] netHitColliders = Physics.OverlapSphere(target.transform.position, fishingNetSize);

                if (netHitColliders.Length > bestTargetAmount && hitColliders[i].gameObject.tag == "Enemy")
                {
                    bestTarget = hitColliders[i];
                    bestTargetAmount = netHitColliders.Length;
                    bestTargetDirection = transform.position - hitColliders[i].transform.position;
                }

                if (timer >= attackSpeed)
                {
                    Instantiate(projectile, transform.position, Quaternion.identity);
                    timer = 0;
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

    public Vector3 getBestTargetPosition()
    {
        return bestTarget.transform.position;
    }

    public float getProjectileSpeed()
    {
        return projectileSpeed;
    }

    public int getAttackDamage()
    {
        return projectileDamage;
    }

    public float getNetSize()
    {
        return fishingNetSize;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
        if (bestTarget != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(bestTarget.transform.position, fishingNetSize);
        }
    }
}
