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
    private GameObject clone;
    private Player player;
    private Weapon gun;
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
            clone = Instantiate(weaponToInstantiate, transform.position, transform.rotation);

            player.vignes--;

            SetWeaponInHand();
        }
        else if (weaponRarityNumber > 12 && weaponRarityNumber <= 17)
        {
            // Rare Weapon
            weaponToInstantiate = rareWeapon[Random.Range(0, rareWeapon.Length)];
            clone = Instantiate(weaponToInstantiate, transform.position, transform.rotation);

            player.vignes--;

            SetWeaponInHand();
        }
        else if (weaponRarityNumber > 17)
        {
            // Epic Weapon
            weaponToInstantiate = epicWeapon[Random.Range(0, epicWeapon.Length)];
            clone = Instantiate(weaponToInstantiate, transform.position, transform.rotation);

            player.vignes--;

            SetWeaponInHand();
        }
    }

    private void SetWeaponInHand()
    {
        gun = clone.GetComponent<Weapon>();

        // On sélectionne le slot d'arme actuellement en main
        if (player.weaponInHand.transform.childCount == 0)
        {
            GunBlockPos();

            // On modifie le parent de mon arme
            gun.transform.SetParent(player.weaponInHand.transform, true);

            GunChangePos();
        }
        else
        {
            for (gun.hand = 0; gun.hand < player.inventory.Length; gun.hand++)
            {
                if (player.inventory[gun.hand].transform.childCount == 0)
                {
                    GunBlockPos();

                    // On modifie le parent de mon arme
                    gun.transform.SetParent(player.inventory[gun.hand].transform, true);

                    GunChangePos();

                    return;
                }
            }

            // On prend alors l'arme en main que l'on retire et on la remplace par celle ci
            if (gun.hand == player.inventory.Length)
            {
                // On retire l'autre arme de son parent
                player.weaponInHand.GetComponentInChildren<Weapon>().rbGun.isKinematic = false;
                player.weaponInHand.GetComponentInChildren<Weapon>().transform.SetParent(player.weaponInHand.transform, false);

                GunBlockPos();

                // On modifie le parent de mon arme
                gun.transform.SetParent(player.weaponInHand.transform, true);

                GunChangePos();
            }
        }
    }

    private void GunChangePos()
    {
        // On modifie sa position et sa rotation
        gun.transform.localPosition = Vector3.forward;
        gun.transform.localRotation = Quaternion.identity;

        // On récupère le playerInput
        gun.playerInput = player.GetComponentInParent<PlayerInput>();
    }

    private void GunBlockPos()
    {
        gun.blockInteract = false;

        gun.rbGun.isKinematic = true;
    }
    #endregion
}