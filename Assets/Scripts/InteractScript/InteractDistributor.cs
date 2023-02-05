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
    private bool interactLimit;
    [Tooltip("Temps avant de pouvoir interagir de nouveau")]
    [SerializeField] private float interactTimer;
    private float interactableTime;
    private Transform spawnParent;
    private int incrementation;
    #endregion


    #region Built In Methods
    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (interactLimit)
        {
            interactableTime += Time.deltaTime;

            if (interactableTime > interactTimer)
            {
                interactLimit = false;
                interactableTime = 0;
            }
        }
    }
    #endregion


    #region Functions
    public override void Interact()
    {
        if (player.vignes > 0 && !interactLimit)
        {
            interactLimit = true;
            RandomWeapon();
        }
    }

    private void ChoseParent()
    {
        if (player.weaponInHand.transform.childCount == 0)
        {
            spawnParent = player.weaponInHand.transform;
        }
        else
        {
            for (incrementation = 0; incrementation < player.inventory.Length; incrementation++)
            {
                if (player.inventory[incrementation].transform.childCount == 0)
                {
                    spawnParent = player.inventory[incrementation].transform;

                    return;
                }
            }

            // On prend alors l'arme en main que l'on retire et on la remplace par celle ci
            if (incrementation == player.inventory.Length)
            {
                // On retire l'autre arme de son parent
                player.weaponInHand.GetComponentInChildren<Weapon>().rbGun.isKinematic = false;
                player.weaponInHand.GetComponentInChildren<Weapon>().transform.SetParent(player.weaponInHand.transform, false);

                spawnParent = player.weaponInHand.transform;
            }
        }
    }

    private void RandomWeapon()
    {
        weaponRarityNumber = Random.Range(0, 20);

        if (weaponRarityNumber >= 0 && weaponRarityNumber <= 12)
        {
            // Common Weapon
            weaponToInstantiate = commonWeapon[Random.Range(0, commonWeapon.Length)];

            WeaponSpawnRoutine();
        }
        else if (weaponRarityNumber > 12 && weaponRarityNumber <= 17)
        {
            // Rare Weapon
            weaponToInstantiate = rareWeapon[Random.Range(0, rareWeapon.Length)];

            WeaponSpawnRoutine();
        }
        else if (weaponRarityNumber > 17)
        {
            // Epic Weapon
            weaponToInstantiate = epicWeapon[Random.Range(0, epicWeapon.Length)];

            WeaponSpawnRoutine();
        }
    }

    private void WeaponSpawnRoutine()
    {
        ChoseParent();

        clone = Instantiate(weaponToInstantiate, spawnParent.transform.position, spawnParent.transform.rotation, spawnParent);

        gun = clone.GetComponent<Weapon>();

        gun.playerInput = player.GetComponentInParent<PlayerInput>();

        gun.blockInteract = false;

        gun.GetComponent<Rigidbody>().isKinematic = true;

        player.vignes--;
    }
    #endregion
}