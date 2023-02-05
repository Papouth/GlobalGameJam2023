using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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

    [SerializeField] private AudioClip shotSound;
    public int hand;
    public bool blockInteract;

    [Header("Component")]
    public Collider colWeapon;
    public PlayerInput playerInput;
    private CharacterController cc;
    private Animator animPlayer;
    private Player player;
    public Rigidbody rbGun;
    private AudioSource audioSource;
    #endregion


    #region Built In Methods
    private void Start()
    {
        cc = FindObjectOfType<CharacterController>();
        player = FindObjectOfType<Player>();
        colWeapon = GetComponent<Collider>();
        rbGun = GetComponent<Rigidbody>();
        audioSource= GetComponent<AudioSource>();   

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

    }

    private void Shoot()
    {
        if (playerInput != null)
        {
            if (playerInput.CanShoot && ammoCount > 0)
            {
                if (!singleShot)
                {
                    Instantiate(bulletPrefab, transform.position, transform.rotation);

                    WeaponRecoil();
                    PlayerRecoil();

                    // Son
                    audioSource.PlayOneShot(shotSound);

                    ammoCount--;

                    singleShot = true;
                }

                time += Time.deltaTime;

                if (time > fireRate)
                {
                    Instantiate(bulletPrefab, transform.position, transform.rotation);

                    WeaponRecoil();
                    PlayerRecoil();

                    // Son
                    audioSource.PlayOneShot(shotSound);

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