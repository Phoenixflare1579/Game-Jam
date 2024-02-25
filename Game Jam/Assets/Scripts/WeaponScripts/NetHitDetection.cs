using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetHitDetection : MonoBehaviour
{
    private Rigidbody rb;
    private BoxCollider collider;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject weaponHolder;
    [SerializeField] private GameObject weapon;
    [SerializeField] private float speed;
    [SerializeField] private float size;
    private Vector3 targetPosition;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        weaponHolder = player.transform.GetChild(0).gameObject;
        //weapon = weaponHolder.transform.GetChild(0).gameObject;
        for (int i = 0; i < weaponHolder.transform.childCount; i++)
        {
            if (weaponHolder.transform.GetChild(i).gameObject.name == "FishingNetWeapon")
            {
                weapon = weaponHolder.transform.GetChild(i).gameObject;
            }
        }

        Vector3 launchDirection = weapon.GetComponent<FishingNetAim>().getBestTargetDirection();
        targetPosition = weapon.GetComponent<FishingNetAim>().getBestTargetPosition();

        speed = weapon.GetComponent<FishingNetAim>().getProjectileSpeed();
        size = weapon.GetComponent<FishingNetAim>().getNetSize();

        collider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();

        transform.rotation = Quaternion.Euler(90, 0, 0);
        transform.localScale = new Vector3(size, size, size);
        rb.AddForce((targetPosition - transform.position).magnitude*0.8f * new Vector3(0,1,0), ForceMode.Impulse);
        rb.velocity = -speed * launchDirection.normalized;
    }


    void Update()
    {
        if (transform.position.y < -1)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Collider[] hitColliders = Physics.OverlapBox(transform.position, new Vector3(size, size, size));

        foreach (Collider collider in hitColliders)
        {
            if (collider.tag == "Enemy")
            {
                Enemy_AI enemy = collider.gameObject.GetComponent<Enemy_AI>();
                if (enemy != null)
                {
                    enemy.setHP(enemy.getHP() - weapon.GetComponent<FishingNetAim>().getAttackDamage());
                }
            }
        }
        Destroy(gameObject);
    }
}
