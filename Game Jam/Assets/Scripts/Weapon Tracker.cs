using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponTracker : MonoBehaviour
{
    GameObject player;
    public Sprite[] weapons1;
    public Sprite[] weapons2;      
    public Sprite[] weapons3;
    public Sprite[] weapons4;
    public Sprite[] weapons5;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player.GetComponent<PlayerStats>().Weapon == 1)
        {
            this.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Fishing Rod";
            this.GetComponent<Image>().sprite = weapons1[player.GetComponent<PlayerStats>().Upgrade];
        }
        else if (player.GetComponent<PlayerStats>().Weapon == 2)
        {
            this.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Fishing Net";
            this.GetComponent<Image>().sprite = weapons2[player.GetComponent<PlayerStats>().Upgrade];
        }
        else if (player.GetComponent<PlayerStats>().Weapon == 3)
        {
            this.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Harpoon Gun";
            this.GetComponent<Image>().sprite = weapons3[player.GetComponent<PlayerStats>().Upgrade];
        }
        else if (player.GetComponent<PlayerStats>().Weapon == 4)
        {
            this.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Fishing Spear";
            this.GetComponent<Image>().sprite = weapons4[player.GetComponent<PlayerStats>().Upgrade];
        }
        else if (player.GetComponent<PlayerStats>().Weapon == 5)
        {
            this.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Anchor";
            this.GetComponent<Image>().sprite = weapons5[player.GetComponent<PlayerStats>().Upgrade];
        }
    }
}
