using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordfishStats : EnemyStats
{
    void Start()
    {
        HP = 15;
        attackRange = 4;
        attackDamage = 7;
        attackCooldown = 1;
        speed = 3;
        EXP = 15;
    }
}
