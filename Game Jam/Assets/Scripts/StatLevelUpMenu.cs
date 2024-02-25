using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StatLevelUpMenu : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LevelMaxHp()
    {
        player.GetComponent<PlayerStats>().MaxHP += 10;
        player.GetComponent<PlayerStats>().HP = player.GetComponent<PlayerStats>().MaxHP;
        Time.timeScale = 1;
    }
    public void LevelAttack()
    {
        player.GetComponent<PlayerStats>().Attack += 1;
        Time.timeScale = 1;
    }
    public void LevelDefense()
    {
        player.GetComponent<PlayerStats>().Def += 1;
        Time.timeScale = 1;
    }
    public void LevelSpeed()
    { 
        player.GetComponent<PlayerStats>().Speed += 1;
        Time.timeScale = 1;
    }
    public void LevelAttackSpeed()
    {
        player.GetComponent<PlayerStats>().AttackSpeed += 1;
        Time.timeScale = 1;
    }
}
