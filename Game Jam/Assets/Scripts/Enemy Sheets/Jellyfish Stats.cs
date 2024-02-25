using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyfishStats : EnemyStats
{
    void Start()
    {
        HP = 5;
        attackRange = 3;
        attackDamage = 2;
        attackCooldown = 1;
        speed = 5;
        EXP = 10;
    }
}
