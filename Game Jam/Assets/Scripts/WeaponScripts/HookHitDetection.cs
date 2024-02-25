using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookHitDetection : MonoBehaviour
{
    private Rigidbody rb;
    private BoxCollider collider;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject weaponHolder;
    [SerializeField] private GameObject weapon;
    [SerializeField] private float speed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        weaponHolder = player.transform.GetChild(0).gameObject;
        weapon = weaponHolder.transform.GetChild(0).gameObject;

        Vector3 launchDirection = weapon.GetComponent<RodAim>().getBestTargetDirection();
        speed = weapon.GetComponent<RodAim>().getProjectileSpeed();

        collider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.Euler(90, 0, 0);
        rb.velocity = -speed*launchDirection.normalized;   
    }


    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            Enemy_AI enemy = collision.collider.gameObject.GetComponent<Enemy_AI>();
            enemy.setHP(enemy.getHP() - weapon.GetComponent<RodAim>().getAttackDamage());
            Destroy(gameObject);
        }
    }
}
