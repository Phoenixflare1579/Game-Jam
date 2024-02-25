using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunaStats : EnemyStats
{
    // Start is called before the first frame update
    void Start()
    {
        HP = 20;
        attackRange = 3;
        attackDamage = 5;
        attackCooldown = 1;
        speed = 3;
        EXP = 10;
    }
}
