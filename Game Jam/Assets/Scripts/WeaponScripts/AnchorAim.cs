using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorAim : MonoBehaviour
{
    [SerializeField] private float range = 10;
    [SerializeField] private float attackSpeed = 1;
    [SerializeField] private float spearSize = 2;
    [SerializeField] private Collider[] hitColliders;
    [SerializeField] private Collider bestTarget;
    [SerializeField] private Vector3 bestTargetDirection;
    [SerializeField] private float bestTargetDistance;
    [SerializeField] private bool attackSide; //0 for left, 1 for right
    [SerializeField] private List<Collider> attackColliders;
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
        bestTargetDistance = range;
        bestTarget = null; 
        attackColliders = new List<Collider>();

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
                }
            }

            if (bestTargetDirection.x < 0)
            {
                attackSide = false;
            }
            else
            {
                attackSide = true;
            }

            for (int i = 0; i < hitColliders.Length; i++)
            {
                if (hitColliders[i].transform.position.x < transform.position.x && attackSide)
                {
                    attackColliders.Add(hitColliders[i]);
                }
                else if (hitColliders[i].transform.position.x > transform.position.x && !attackSide)
                {
                    attackColliders.Add(hitColliders[i]);
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
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
        if (bestTarget != null)
        {
            Gizmos.color = Color.green;
            if (attackColliders.Count > 0)
            {
                for (int i = 0; i < attackColliders.Count; i++)
                {
                    Gizmos.DrawSphere(attackColliders[i].transform.position, 0.5f);
                }
            }
            Gizmos.DrawLine(transform.position, bestTarget.transform.position);
        }
    }
}
