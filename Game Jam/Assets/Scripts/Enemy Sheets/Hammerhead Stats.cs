using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerheadStats : EnemyStats
{
    void Start()
    {
        HP = 200;
        attackRange = 2;
        attackDamage = 15;
        attackCooldown = 2;
        speed = 1;
    }
}
