using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StatLevelUpMenu : MonoBehaviour
{
    public Text levelText;
    public Text maxHPText;
    public Text atkText;
    public Text speedText;
    public Text defText;
    public Text attackSpeedText;
    public Text dodgeText;
    public PlayerStats playerStats;
    public int choice;

    // Start is called before the first frame update
    void Start()
    {
        choice = 0;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateUI()
    {
        levelText.text = "Level: " + playerStats.Level.ToString();
        maxHPText.text = "Max HP: " + playerStats.MaxHP.ToString();
        atkText.text = "Attack: " + playerStats.Attack.ToString();
        speedText.text = "Speed: " + playerStats.Speed.ToString();
        defText.text = "Defense: " + playerStats.Def.ToString();
        attackSpeedText.text = "Attack Speed: " + playerStats.Attack.ToString();
        dodgeText.text = " Dodge: " + playerStats.Dodge.ToString();
    }

    public void LevelUpStats(int choice)
    {
        if (choice == 1) //MaxHP
        {
            playerStats.MaxHP += 10;
            UpdateUI();
        }
        else if (choice == 2) //Attack 
        {
            playerStats.Attack += 1;
            UpdateUI();
        }
        else if (choice == 3) //Speed
        {
            playerStats.Speed += 1;
            UpdateUI();
        }
        else if (choice == 4) //Defense
        {
            playerStats.Def += 10;
            UpdateUI();
        }
        else if (choice == 5) //Attack Speed
        {
            playerStats.AttackSpeed += 1;
            UpdateUI();
        }
        else if (choice == 6)//Dodge
        {
            playerStats.Dodge += 1;
            UpdateUI();
        }
    }

}
