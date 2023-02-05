using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variables
    [Header("Player Parameters")]
    public int playerLife = 100;
    [Tooltip("Nombre de temps avant le respawn du joueur")]
    [SerializeField] private float timeBeforeSpawn;
    private float timerRespawn;

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
    private PlayerMovement playerMovement;
    #endregion


    #region Built In Methods
    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        playerMovement = GetComponent<PlayerMovement>();
        timerRespawn = 0f;

        InventoryChecker();
    }

    private void Update()
    {
        WeaponCheckStatut();

        ShootStatut();

        Inventory();

        Respawn();
    }
    #endregion


    #region Functions
    private void Respawn()
    {
        if (playerLife <= 0)
        {
            // On immobilise le joueur
            playerMovement.dead = true;

            // Anim joueur meurt
            playerAnimator.SetBool("Dead", true);

            timeBeforeSpawn -= Time.deltaTime;

            if (timeBeforeSpawn < timerRespawn)
            {
                // On débloque le joueur
                playerMovement.dead = false;

                // Anim retour en idle
                playerAnimator.SetBool("Dead", false);

                timeBeforeSpawn = 0;
            }
        }
    }

    /// <summary>
    /// Permet de véirifier si le joueur possède une arme au start
    /// </summary>
    private void InventoryChecker()
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            inventory[i].gameObject.SetActive(false);
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