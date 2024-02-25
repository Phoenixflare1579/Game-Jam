using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownfishStats : EnemyStats
{
    // Start is called before the first frame update
    void Start()
    {
        HP = 30;
        attackRange = 5;
        attackDamage = 7;
        attackCooldown = 1;
        speed = 2;
    }

}
