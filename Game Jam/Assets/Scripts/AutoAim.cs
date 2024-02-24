using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAim : MonoBehaviour
{
    public float range;
    public float attackSpeed;
    public Collider[] hitColliders;
    public Collider closestTarget;
    float closestTargetDistance;
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(0,0,0);
        closestTargetDistance = range;
    }

    // Update is called once per frame
    void Update()
    {
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
                    closestTargetDistance = (transform.position - closestTarget.transform.position).magnitude;
                }
            }

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
