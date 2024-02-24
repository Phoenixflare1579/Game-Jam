using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class WeaponLevelUp : MonoBehaviour
{
    GameObject player;
    GameObject panel;
    int prevWeapon;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        panel = GameObject.FindGameObjectWithTag("WeaponLevelUpPanel");
        panel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpgradeWeapon()
    {
       
    }

    public void ChangeWeapon()
    {


    }

    public void RevertWeapon()
    {
        int temp = prevWeapon; //store previous weapon into temp
        prevWeapon = player.GetComponent<PlayerStats>().Weapon; //store current weapon as new prev weapon
        player.GetComponent<PlayerStats>().Weapon = temp; //new weapon is previous weapon
    }

}
