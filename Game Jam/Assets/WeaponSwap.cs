using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject weaponHolder;
    [SerializeField] private GameObject weapon;
    [SerializeField] private List<GameObject> weaponList;
    private PlayerStats playerStats;
    private int playerWeapon;
    private int currentWeapon;
    // Start is called before the first frame update
    void Start()
    {
        currentWeapon = 1;
        weapon = Instantiate(weaponList[currentWeapon], transform.position, Quaternion.identity);

        player = GameObject.FindGameObjectWithTag("Player");
        weaponHolder = player.transform.GetChild(0).gameObject;
        weapon = weaponHolder.transform.GetChild(0).gameObject;

        playerStats = player.gameObject.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        playerWeapon = playerStats.Weapon;
        currentWeapon = getWeaponID();

        if (playerWeapon != currentWeapon) 
        {
            Destroy(weapon);
            weapon = Instantiate(weaponList[playerWeapon], transform.position, Quaternion.identity);
        }
    }

    public int getWeaponID()
    {
        if (weapon.name == "FishingRodWeapon")
        { return 1;}
        else if (weapon.name == "FishingNetWeapon")
        { return 2;}
        else if (weapon.name == "HarpoonGunWeapon")
        { return 3;}
        else if (weapon.name == "FishingSpearWeapon")
        { return 4;}
        else if(weapon.name == "AnchorWeapon")
        { return 5;}
        else
        { return 1;}
    }
}
