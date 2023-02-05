using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variables
    [Header("Player Parameters")]
    public int playerLife = 100;

    [Header("Player Inventory")]
    private Vector3 mouseWheelInput;
    public GameObject[] inventory = new GameObject[3];
    public GameObject weaponInHand;
    [SerializeField] private int actualNumber;
    public bool haveWeapon;

    public int vignes = 0;

    [Header("Player Component")]
    public Animator playerAnimator;
    private Weapon weapon;
    private PlayerInput playerInput;
    #endregion



    #region Built In Methods
    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();

        InventoryChecker();
    }

    private void Update()
    {
        WeaponCheckStatut();

        ShootStatut();

        Inventory();
    }
    #endregion


    #region Functions
    /// <summary>
    /// Permet de véirifier si le joueur possède une arme au start
    /// </summary>
    private void InventoryChecker()
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i].transform.childCount != 0) 
            {
                weapon = inventory[i].GetComponentInChildren<Weapon>();

                inventory[i].gameObject.SetActive(false);
            }
        }

        weaponInHand = inventory[0];
        weaponInHand.SetActive(true);
        actualNumber = 0;
    }


    /// <summary>
    /// Si on a une arme en enfant de la main actuelle
    /// </summary>
    private void WeaponCheckStatut()
    {
        if (weaponInHand.transform.childCount != 0) 
        {
            weapon = weaponInHand.GetComponentInChildren<Weapon>();

            if (weapon.gameObject.activeSelf) playerAnimator.SetBool("BigWeapon", true);
            else if (!weapon.gameObject.activeSelf) playerAnimator.SetBool("BigWeapon", false);
        }
    }

    private void ShootStatut()
    {
        if (playerInput.CanShoot) playerAnimator.SetBool("isShooting", true);
        else if (!playerInput.CanShoot) playerAnimator.SetBool("isShooting", false);
    }

    private void Inventory()
    {
        mouseWheelInput = playerInput.WheelInput;

        if (mouseWheelInput.y > 0.1f)
        {
            // On cache l'arme d'avant
            weaponInHand.SetActive(false);

            actualNumber = actualNumber + 1;

            if (actualNumber > inventory.Length - 1) actualNumber = 0;

            weaponInHand = inventory[actualNumber];

            // On cache l'arme d'avant
            weaponInHand.SetActive(true);
        }
        else if (mouseWheelInput.y < -0.1f)
        {
            // On cache l'arme d'avant
            weaponInHand.SetActive(false);

            actualNumber = actualNumber - 1;

            if (actualNumber < 0) actualNumber = 2;

            weaponInHand = inventory[actualNumber];

            // On cache l'arme d'avant
            weaponInHand.SetActive(true);
        }
    }
    #endregion
}