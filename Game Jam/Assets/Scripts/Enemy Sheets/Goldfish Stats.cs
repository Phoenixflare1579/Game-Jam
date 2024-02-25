using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldfishStats : EnemyStats
{
    // Start is called before the first frame update
    void Start()
    {
        HP = 10;
        attackRange = 2;
        attackDamage = 3;
        attackCooldown = 0.5f;
        speed = 4;
    }
}
