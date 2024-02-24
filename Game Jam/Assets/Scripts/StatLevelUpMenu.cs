using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StatLevelUpMenu : MonoBehaviour
{
    GameObject player;
    public Text levelText;
    public Text maxHPText;
    public Text atkText;
    public Text speedText;
    public Text defText;
    public Text attackSpeedText;
    public Text dodgeText;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateUI()
    {
        //levelText.text = "Level: " + playerStats.Level.ToString();
       // maxHPText.text = "Max HP: " + playerStats.MaxHP.ToString();
        //atkText.text = "Attack: " + playerStats.Attack.ToString();
        //speedText.text = "Speed: " + playerStats.Speed.ToString();
        //defText.text = "Defense: " + playerStats.Def.ToString();
        //attackSpeedText.text = "Attack Speed: " + playerStats.Attack.ToString();
       // dodgeText.text = " Dodge: " + playerStats.Dodge.ToString();
    }

    public void LevelMaxHp()
    {
        player.GetComponent<PlayerStats>().MaxHP += 10;
        UpdateUI();
    }
    public void LevelAttack()
    {
        player.GetComponent<PlayerStats>().Attack += 1;
        UpdateUI();
    }
    public void LevelSpeed()
    { 
        player.GetComponent<PlayerStats>().Speed += 1;
        UpdateUI();
    }
    public void levelAttackSpeed()
    {
        player.GetComponent<PlayerStats>().AttackSpeed += 1;
        UpdateUI();
    }
    public void LevelDodge() 
    { 
        player.GetComponent<PlayerStats>().Dodge += 1;
        UpdateUI();
    }
}
