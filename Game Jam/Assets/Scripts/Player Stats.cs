using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int MaxHP;
    public int HP;
    public int MaxEXP;
    public int EXP;
    public int Level;
    public float Dodge;
    public float Speed;
    public int Attack;
    public float AttackSpeed;
    public int Def;
    public int Weapon;
    public int Upgrade;
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
        Weapon = 1;
        Upgrade = 0;
        Level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (EXP >= MaxEXP) 
        {
            EXP -= MaxEXP;
            Level++;
            MaxEXP += 100; //This is a test value we don't need to keep this number increase
        }
    }
}
