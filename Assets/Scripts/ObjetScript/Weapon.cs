using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    #region Variables
    [Header("Munitions")]
    [SerializeField] private int ammoCount;
    [SerializeField] private int ammoInMag;
    [SerializeField] private int magazineCount;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawn;

    [Header("Weapon FireRate")]
    [SerializeField] private float fireRate;
    private float time = 0f;
    private bool singleShot;

    [Header("Weapon Recoil")]
    [SerializeField] private float recoilGunAmount;
    private float timeRecoil = 0f;
    private float recoilLimitTimer;
    private bool recoilWeapon;

    //private Transform playerTransform;
    [SerializeField] private float valueRecoilPlayer;
    private Vector3 recoilPlayer;
    [SerializeField] private AudioSource shotSound;
    [SerializeField] private GameObject bulletCasing;
    [SerializeField] private Transform bulletCasingPos;

    [Header("Component")]
    [SerializeField] private PlayerInput playerInput;
    private CharacterController cc;
    #endregion

    #region Built In Methods
    private void Start()
    {
        cc = GetComponentInParent<CharacterController>();
        playerInput = GetComponentInParent<PlayerInput>();
        //playerTransform = GetComponentInParent<Transform>();

        recoilLimitTimer = fireRate / 5f;
    }

    private void Update()
    {
        Shoot();

        Relaod();

        WeaponRecoilTimer();
    }
    #endregion

    #region Functions
    private void Shoot()
    {
        if (playerInput.CanShoot)
        {
            if (!singleShot)
            {
                Instantiate(bulletPrefab, transform.position, transform.rotation);

                WeaponRecoil();
                PlayerRecoil();

                ammoCount--;

                singleShot = true;
            }

            time += Time.deltaTime;

            if (time > fireRate)
            {
                Instantiate(bulletPrefab, transform.position, transform.rotation);

                WeaponRecoil();
                PlayerRecoil();

                ammoCount--;

                time = 0f;
            }
        }
        else if (!playerInput.CanShoot)
        {
            singleShot = false;
            time = 0f;
        }
    }

    private void Relaod()
    {
        // Out Of Ammo Reload
        if (ammoCount == 0 && magazineCount > 0)
        {
            // Reset du nombre de balle dans le chargeur
            ammoCount = ammoInMag;

            // On retire un chargeur au joueur
            magazineCount--;
        }
    }

    private void WeaponRecoil()
    {
        transform.localRotation = Quaternion.Euler(Random.Range(2f, 15f), 0f, 0f);

        recoilWeapon = true;
    }

    private void WeaponRecoilTimer()
    {
        if (recoilWeapon)
        {
            timeRecoil += Time.deltaTime;

            if (timeRecoil > recoilLimitTimer)
            {
                transform.localRotation = Quaternion.identity;

                recoilWeapon = false;

                timeRecoil = 0f;
            }
        }
    }

    private void PlayerRecoil()
    {
        recoilPlayer = cc.transform.TransformDirection(0f, 0f, -transform.localPosition.z - valueRecoilPlayer);

        cc.Move(recoilPlayer);
    }
    #endregion
}