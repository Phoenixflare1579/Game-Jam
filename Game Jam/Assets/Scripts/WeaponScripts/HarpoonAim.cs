using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonAim : MonoBehaviour
{
    [SerializeField] private float range = 20;
    [SerializeField] private float attackSpeed = 1;
    [SerializeField] private float harpoonSize = 2;
    [SerializeField] private float harpoonShotDistance = 40;
    [SerializeField] private Collider[] hitColliders;
    [SerializeField] private Collider bestTarget;
    [SerializeField] private Vector3 bestTargetDirection;
    [SerializeField] private float bestTargetAmount;
    [SerializeField] private GameObject weapon;

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
        bestTargetAmount = 0;
        bestTarget = null;

        hitColliders = Physics.OverlapSphere(transform.position, range);
        if (hitColliders.Length > 0)
        {
            for (int i = 0; i < hitColliders.Length; i++)
            {
                Collider target = hitColliders[i];
                Vector3 targetDirection = hitColliders[i].transform.position - transform.position;
                RaycastHit[] harpoonHitColliders = Physics.SphereCastAll(transform.position, harpoonSize / 2, targetDirection, harpoonShotDistance);

                if (harpoonHitColliders.Length > bestTargetAmount && hitColliders[i].gameObject.tag == "Enemy")
                {
                    bestTarget = hitColliders[i];
                    bestTargetAmount = harpoonHitColliders.Length;
                    bestTargetDirection = -targetDirection;
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

    void OnDrawGizmos()
    {
        if (bestTarget != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, range);

            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position - harpoonShotDistance * bestTargetDirection.normalized);

            float angle = Vector3.SignedAngle(bestTargetDirection, new Vector3(1,0,0), Vector3.up) * Mathf.PI/180;

            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position + new Vector3(harpoonSize * Mathf.Cos(angle - Mathf.PI/2), 0, harpoonSize * Mathf.Sin(angle - Mathf.PI / 2)), 
                            transform.position - harpoonShotDistance*bestTargetDirection.normalized + new Vector3(harpoonSize * Mathf.Cos(angle - Mathf.PI / 2), 0, harpoonSize * Mathf.Sin(angle - Mathf.PI / 2)));
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position + new Vector3(harpoonSize * Mathf.Cos(angle + Mathf.PI / 2), 0, harpoonSize * Mathf.Sin(angle + Mathf.PI / 2)),
                            transform.position - harpoonShotDistance * bestTargetDirection.normalized + new Vector3(harpoonSize * Mathf.Cos(angle + Mathf.PI / 2), 0, harpoonSize * Mathf.Sin(angle + Mathf.PI / 2)));
        }
    }
}
