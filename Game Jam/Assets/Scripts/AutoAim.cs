using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAim : MonoBehaviour
{
    public float range;
    public float attackSpeed;
    public Collider[] hitColliders;
    public Collider clostestTarget;
    float clostestTargetDistance;
    // Start is called before the first frame update
    void Start()
    {
        clostestTargetDistance = range;
    }

    // Update is called once per frame
    void Update()
    {
        clostestTargetDistance = range;
        clostestTarget = null;
        hitColliders = Physics.OverlapSphere(transform.position, range);
        if (hitColliders.Length > 0)
        {
            for (int i = 0; i < hitColliders.Length; i++)
            {
                float targetDistance = (transform.position - hitColliders[i].transform.position).magnitude;
                if (targetDistance < clostestTargetDistance && hitColliders[i].gameObject.tag == "Enemy")
                {
                    clostestTarget = hitColliders[i];
                    clostestTargetDistance = (transform.position - clostestTarget.transform.position).magnitude;
                }
            }

        }
    }

    void OnDrawGizmos()
    {
        if (clostestTarget != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, clostestTarget.transform.position);
        }
    }
}
