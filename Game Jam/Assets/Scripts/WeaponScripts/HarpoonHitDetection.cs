using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonHitDetection : MonoBehaviour
{
    private Rigidbody rb;
    private BoxCollider collider;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject weaponHolder;
    [SerializeField] private GameObject weapon;
    [SerializeField] private float speed;
    [SerializeField] private float size;
    private HashSet<Collider> projectileHitSet;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        weaponHolder = player.transform.GetChild(0).gameObject;
        weapon = weaponHolder.transform.GetChild(0).gameObject;

        Vector3 launchDirection = weapon.GetComponent<HarpoonAim>().getBestTargetDirection();
        speed = weapon.GetComponent<HarpoonAim>().getProjectileSpeed();
        size = weapon.GetComponent<HarpoonAim>().getHarpoonSize();

        collider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.Euler(90, 0, Vector3.SignedAngle(launchDirection, Vector3.back, Vector3.up));
        rb.velocity = -speed * launchDirection.normalized;

        projectileHitSet = new HashSet<Collider>();
    }


    void Update()
    {
        if ((transform.position - player.transform.position).magnitude > 40) 
        {
            Destroy(gameObject);
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
                        enemy.setHP(enemy.getHP() - weapon.GetComponent<HarpoonAim>().getAttackDamage());
                    }
                    projectileHitSet.Add(collider);
                }
            }
        }
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.tag == "Enemy")
    //    {
    //        Enemy_AI enemy = collision.collider.gameObject.GetComponent<Enemy_AI>();
    //        enemy.setHP(enemy.getHP() - weapon.GetComponent<HarpoonAim>().getAttackDamage());
    //        Destroy(gameObject);
    //    }
    //}
}
