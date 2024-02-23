using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthTracker : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Slider>().maxValue = player.GetComponent<PlayerStats>().MaxHP;
        this.GetComponent<Slider>().value = player.GetComponent<PlayerStats>().HP;
        this.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = player.GetComponent<PlayerStats>().HP + "/" + player.GetComponent<PlayerStats>().MaxHP;
    }
}
