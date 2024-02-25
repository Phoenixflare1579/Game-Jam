using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidStats : EnemyStats
{
    void Start()
    {
        HP = 150;
        attackRange = 4;
        attackDamage = 10;
        attackCooldown = 1;
        speed = 3;
        EXP = 250;
    }
}
