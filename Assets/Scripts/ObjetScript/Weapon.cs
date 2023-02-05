using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : Interactable
{
    #region Variables
    [Header("Munitions")]
    [SerializeField] private int ammoCount;
    [SerializeField] private int ammoInMag;
    public int magazineCount;
    [HideInInspector] public int magazineCountBase;
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

    [Header("Player Recoil")]
    [SerializeField] private float valueRecoilPlayer;
    private Vector3 recoilPlayer;

    private float reloadTime = 3.2f;
    private float timerToReload = 0f;

    [SerializeField] private AudioSource shotSound;
    [SerializeField] private GameObject bulletCasing;
    [SerializeField] private Transform bulletCasingPos;

    [Header("Component")]
    private PlayerInput playerInput;
    private CharacterController cc;
    private Animator animPlayer;
    private Player player;
    #endregion


    #region Built In Methods
    private void Start()
    {
        cc = GetComponentInParent<CharacterController>();
        player = FindObjectOfType<Player>();

        recoilLimitTimer = fireRate / 5f;

        magazineCountBase = magazineCount;
    }

    private void Update()
    {
        Shoot();

        Relaod();

        WeaponRecoilTimer();
    }
    #endregion


    #region Functions
    public override void Interact()
    {
        // On met l'objet dans la main du joueur et on disable le collider
        playerInput = player.GetComponent<PlayerInput>();

        if (player.weaponInHand.transform.childCount == 0)
        {
            transform.SetParent(player.weaponInHand.transform, true);
            transform.position = Vector3.forward;
            transform.rotation = Quaternion.identity;
        }

    }

    private void Shoot()
    {
        if (playerInput.CanShoot && ammoCount > 0)
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
            // On joue l'animation de rechargement de l'arme
            animPlayer = GetComponentInParent<Animator>();
            animPlayer.SetTrigger("Reload");

            timerToReload += Time.deltaTime;

            if (timerToReload > reloadTime)
            {
                animPlayer.ResetTrigger("Reload");

                // Reset du nombre de balle dans le chargeur
                ammoCount = ammoInMag;

                // On retire un chargeur au joueur
                magazineCount--;

                timerToReload = 0f;
            }
        }
    }

    private void WeaponRecoil()
    {
        transform.localRotation = Quaternion.Euler(-Random.Range(2f, 15f), 0f, 0f);

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