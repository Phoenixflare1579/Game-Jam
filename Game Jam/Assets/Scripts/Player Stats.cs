using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
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
    public bool changeWeapon;
    public GameObject StatsLevelUp;
    public GameObject WeaponLevelUp;
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
        changeWeapon = true;
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Player_MovewInput>().speed = Speed;
        if (changeWeapon)
        {
            for (int i = 1; i < 6; i++)
            {
                if (i == Weapon)
                {
                    this.transform.GetChild(0).GetChild(i - 1).gameObject.SetActive(true);
                }
                else
                {
                    this.transform.GetChild(0).GetChild(i - 1).gameObject.SetActive(false);
                }
            }
            changeWeapon = false;
        }
        if (EXP >= MaxEXP) 
        {
            Time.timeScale = 0;
            HP = MaxHP;
            EXP -= MaxEXP;
            Level++;
            if (Level % 2 == 0) //if level is even
            {
                WeaponLevelUp.SetActive(true);

            }
            else //level is odd 
            {
                StatsLevelUp.SetActive(true);

            }

            MaxEXP += 100; //This is a test value we don't need to keep this number increase
        }
        
        if (HP <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
