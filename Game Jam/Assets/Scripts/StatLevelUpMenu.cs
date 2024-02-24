using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StatLevelUpMenu : MonoBehaviour
{
    GameObject player;
    GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        panel = GameObject.FindGameObjectWithTag("StatLevelUpPanel");
        panel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LevelMaxHp()
    {
        player.GetComponent<PlayerStats>().MaxHP += 10;
    }
    public void LevelAttack()
    {
        player.GetComponent<PlayerStats>().Attack += 1;
    }
    public void LevelDefense()
    {
        player.GetComponent<PlayerStats>().Def += 1;
    }
    public void LevelSpeed()
    { 
        player.GetComponent<PlayerStats>().Speed += 1;
    }
    public void LevelAttackSpeed()
    {
        player.GetComponent<PlayerStats>().AttackSpeed += 1;
    }
}
