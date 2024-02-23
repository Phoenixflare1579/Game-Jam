using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int MaxHP;
    public int HP;
    public int MaxEXP;
    public int EXP;
    public float Dodge;
    public float Speed;
    public int Attack;
    public float AttackSpeed;
    public int Def;
    // Start is called before the first frame update
    void Start()
    {
        MaxHP = 100;
        HP = MaxHP;
        MaxEXP = 100;
        EXP = 0;
        Dodge = 0.01f;
        Speed = 5f;
        Attack = 5;
        AttackSpeed = 0.25f;
        Def = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
