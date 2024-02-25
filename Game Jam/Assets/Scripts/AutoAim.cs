using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAim : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] private float rodRange;
    [SerializeField] private float netRange;
    [SerializeField] private float harpoonRange;
    [SerializeField] private float spearRange;
    [SerializeField] private float anchorRange;
    [SerializeField] private float attackSpeed;
    [SerializeField] private Collider[] hitColliders;
    [SerializeField] private Collider closestTarget;
    [SerializeField] private Vector3 closestTargetDirection;
    [SerializeField] private float closestTargetDistance;
    [SerializeField] private GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        transform.localPosition = new Vector3(0,0,-0.1f);

        weapon = transform.GetChild(0).gameObject;
        weapon.transform.localPosition = new Vector3(0f, 0f, -0.6f);
        weapon.transform.localRotation = Quaternion.Euler(90f, 0f, 45f);
    }

    // Update is called once per frame
    void Update()
    {
        // Fishing rod
        if (player.GetComponent<PlayerStats>().Weapon == 1)
        {
            float range = rodRange;
            closestTargetDistance = range;
            closestTarget = null;
            hitColliders = Physics.OverlapSphere(transform.position, range);
            if (hitColliders.Length > 0)
            {
                for (int i = 0; i < hitColliders.Length; i++)
                {
                    float targetDistance = (transform.position - hitColliders[i].transform.position).magnitude;
                    if (targetDistance < closestTargetDistance && hitColliders[i].gameObject.tag == "Enemy")
                    {
                        closestTarget = hitColliders[i];
                        closestTargetDirection = transform.position - hitColliders[i].transform.position;
                        closestTargetDistance = (transform.position - closestTarget.transform.position).magnitude;
                    }
                }


                if (closestTargetDirection.x < 0)
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

            transform.rotation = Quaternion.LookRotation(closestTargetDirection);
        }

        // Net
        else if (player.GetComponent<PlayerStats>().Weapon == 2)
        {
            float range = netRange;
            closestTargetDistance = range;
            closestTarget = null;
            hitColliders = Physics.OverlapSphere(transform.position, range);
            if (hitColliders.Length > 0)
            {
                for (int i = 0; i < hitColliders.Length; i++)
                {
                    float targetDistance = (transform.position - hitColliders[i].transform.position).magnitude;
                    if (targetDistance < closestTargetDistance && hitColliders[i].gameObject.tag == "Enemy")
                    {
                        closestTarget = hitColliders[i];
                        closestTargetDirection = transform.position - hitColliders[i].transform.position;
                        closestTargetDistance = (transform.position - closestTarget.transform.position).magnitude;
                    }
                }


                if (closestTargetDirection.x < 0)
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

            transform.rotation = Quaternion.LookRotation(closestTargetDirection);

        }

        // Harpoon Gun
        else if(player.GetComponent<PlayerStats>().Weapon == 3)
        {

        }

        // Fishing Spear
        else if(player.GetComponent<PlayerStats>().Weapon == 4)
        {

        }

        // Anchor
        else if (player.GetComponent<PlayerStats>().Weapon == 5)
        {

        }
    }

    void OnDrawGizmos()
    {
        if (closestTarget != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, closestTarget.transform.position);
        }
    }
}
