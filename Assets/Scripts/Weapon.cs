using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    #region Variables
    [Header("Munitions")]
    [SerializeField] private int ammoCount;
    [SerializeField] private int ammoInMag;
    [SerializeField] private int magazineCount;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawn;

    [Header("Weapon Parameter")]
    [SerializeField] private float fireRate;
    [SerializeField] private Vector3 recoilGun;
    [SerializeField] private Vector3 recoilPlayer;
    [SerializeField] private AudioSource shotSound;
    [SerializeField] private GameObject bulletCasing;
    [SerializeField] private Transform bulletCasingPos;

    [Header("Component")]
    [SerializeField] private PlayerInput playerInput;
    #endregion

    #region Built In Methods
    private void Start()
    {
        playerInput = GetComponentInParent<PlayerInput>();
    }

    private void Update()
    {
        Shoot();
    }
    #endregion

    #region Functions
    private void Shoot()
    {
        if (playerInput.canShoot)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            // ajouter le fire rate entre chaque tir
        }
    }
    #endregion
}