using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDistributor : Interactable
{
    #region Variables
    [SerializeField] private GameObject[] commonWeapon;
    [SerializeField] private GameObject[] rareWeapon;
    [SerializeField] private GameObject[] epicWeapon;
    private int weaponRarityNumber;
    private GameObject weaponToInstantiate;
    private Player player;



    #endregion


    #region Built In Methods
    private void Start()
    {
        player = FindObjectOfType<Player>();    
    }
    #endregion


    #region Functions
    public override void Interact()
    {
        if (player.vignes > 0) RandomWeapon();
    }

    private void RandomWeapon()
    {
        weaponRarityNumber = Random.Range(0, 20);

        if (weaponRarityNumber >= 0 && weaponRarityNumber <= 12)
        {
            // Common Weapon
            weaponToInstantiate = commonWeapon[Random.Range(0, commonWeapon.Length)];
            Instantiate(weaponToInstantiate, transform.position, transform.rotation); // Quaternion.identity
        }
        else if (weaponRarityNumber > 12 && weaponRarityNumber <= 17)
        {
            // Rare Weapon
            weaponToInstantiate = rareWeapon[Random.Range(0, rareWeapon.Length)];
            Instantiate(weaponToInstantiate, transform.position, transform.rotation);
        }
        else if (weaponRarityNumber > 17)
        {
            // Epic Weapon
            weaponToInstantiate = epicWeapon[Random.Range(0, epicWeapon.Length)];
            Instantiate(weaponToInstantiate, transform.position, transform.rotation);
        }

        player.vignes--;
    }
    #endregion
}