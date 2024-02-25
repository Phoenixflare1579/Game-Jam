using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class WeaponLevelUp : MonoBehaviour
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

    public void UpgradeWeapon()
    {
        if (player.GetComponent<PlayerStats>().Weapon != 5)
        {
            int rand = Random.Range(1, 9);
            player.GetComponent<PlayerStats>().Upgrade = rand;
        }
        Time.timeScale = 1;
    }

    public void ChangeWeapon()
    {
        player.GetComponent<PlayerStats>().prevWeapon = player.GetComponent<PlayerStats>().Weapon;
        int rand = Random.Range(0, 6);
        player.GetComponent<PlayerStats>().Weapon = rand;
        player.GetComponent<PlayerStats>().Upgrade = 0;
        Time.timeScale = 1;
    }

    public void RevertWeapon()
    {
        if (player.GetComponent<PlayerStats>().prevWeapon != 0)
        {
            int temp = player.GetComponent<PlayerStats>().prevWeapon; //store previous weapon into temp
            player.GetComponent<PlayerStats>().prevWeapon = player.GetComponent<PlayerStats>().Weapon; //store current weapon as new prev weapon
            player.GetComponent<PlayerStats>().Weapon = temp; //new weapon is previous weapon
            player.GetComponent<PlayerStats>().Upgrade = 0;
        }
        Time.timeScale = 1;
    }

}
