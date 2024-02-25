using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float attackCooldown;
    public float attackRange;
    public int attackDamage;
    public float speed;
    public int HP;
    public int EXP;
    public GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void Update()
    {
        if (HP < 0) 
        {
            player.GetComponent<PlayerStats>().EXP += EXP;
            Destroy(this.gameObject);
        }
    }
}
