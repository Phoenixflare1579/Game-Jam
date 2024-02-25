using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearHitDetection : MonoBehaviour
{
    private Rigidbody rb;
    private BoxCollider collider;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject weaponHolder;
    [SerializeField] private GameObject weapon;
    [SerializeField] private float speed;
    [SerializeField] private float size;
    private HashSet<Collider> projectileHitSet;
    private bool returnToPlayer = false;
    private Vector3 launchPos;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        weaponHolder = player.transform.GetChild(0).gameObject;
        //weapon = weaponHolder.transform.GetChild(0).gameObject;
        for (int i = 0; i < weaponHolder.transform.childCount; i++)
        {
            if (weaponHolder.transform.GetChild(i).gameObject.name == "FishingSpearWeapon")
            {
                weapon = weaponHolder.transform.GetChild(i).gameObject;
            }
        }

        launchPos = player.transform.position;
        Vector3 launchDirection = weapon.GetComponent<SpearAim>().getBestTargetDirection();
        speed = weapon.GetComponent<SpearAim>().getProjectileSpeed();
        size = weapon.GetComponent<SpearAim>().getSpearSize();

        collider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.Euler(90, 0, Vector3.SignedAngle(launchDirection, Vector3.back, Vector3.up) - 45);
        rb.velocity = -speed * launchDirection.normalized;

        projectileHitSet = new HashSet<Collider>();
    }


    void Update()
    {
        if ((transform.position - launchPos).magnitude > weapon.GetComponent<SpearAim>().getRange())
        {
            returnToPlayer = true;
        }

        if (returnToPlayer)
        {
            rb.velocity = speed* (player.transform.position - transform.position);

            if ((transform.position - player.transform.position).magnitude < 1)
            {
                Destroy(gameObject);
            }
        }

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, size);

        foreach (Collider collider in hitColliders)
        {
            if (collider.tag == "Enemy")
            {
                if (!projectileHitSet.Contains(collider))
                {
                    Enemy_AI enemy = collider.gameObject.GetComponent<Enemy_AI>();
                    if (enemy != null)
                    {
                        enemy.setHP(enemy.getHP() - weapon.GetComponent<SpearAim>().getAttackDamage());
                    }
                    projectileHitSet.Add(collider);
                }
            }
        }
    }
}
