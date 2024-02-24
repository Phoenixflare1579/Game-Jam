using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int MaxHP;
    public int HP;
    public int MaxEXP;
    public int EXP;
    public int Level;
    public float Speed;
    public int Attack;
    public float AttackSpeed;
    public int Def;
    public int Weapon;
    public int Upgrade;
    public int prevWeapon;
    // Start is called before the first frame update
    void Start()
    {
        MaxHP = 100;
        HP = MaxHP;
        MaxEXP = 100;
        EXP = 0;
        Speed = 5f;
        Attack = 5;
        AttackSpeed = 0.25f;
        Def = 2;
        Weapon = 1;
        Upgrade = 0;
        Level = 1;
        prevWeapon = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Player_MovewInput>().speed = Speed;
        if (EXP >= MaxEXP) 
        {
            EXP -= MaxEXP;
            Level++;
            MaxEXP += 100; //This is a test value we don't need to keep this number increase
        }
        if (HP <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
