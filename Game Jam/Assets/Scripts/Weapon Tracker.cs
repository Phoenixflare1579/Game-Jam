using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponTracker : MonoBehaviour
{
    GameObject player;
    Image [] weapons1;
    Image[] weapons2;
    Image[] weapons3;
    Image[] weapons4;
    Image[] weapons5;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player.GetComponent<PlayerStats>().Weapon == 1)
        {
            this.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Fishing Rod";
            if (player.GetComponent<PlayerStats>().Upgrade == 0)
            {

            }
        }
        else if (player.GetComponent<PlayerStats>().Weapon == 2)
        {
            this.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Fishing Net";
        }
        else if (player.GetComponent<PlayerStats>().Weapon == 3)
        {
            this.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Harpoon Gun";
        }
        else if (player.GetComponent<PlayerStats>().Weapon == 4)
        {
            this.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Fishing Spear";
        }
        else if (player.GetComponent<PlayerStats>().Weapon == 5)
        {
            this.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Fishing Rod";
        }
    }
}
