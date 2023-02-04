using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerLife = 100;

    [Header("Player Component")]
    private Animator playerAnimator;
    private Weapon weapon;
    private PlayerInput playerInput;



    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        weapon = GetComponentInChildren<Weapon>();
        playerInput = GetComponent<PlayerInput>();  
    }

    private void Update()
    {
        WeaponCheckStatut();

        ShootStatut();
    }

    private void WeaponCheckStatut()
    {
        if (weapon.gameObject.activeSelf) playerAnimator.SetBool("BigWeapon", true);
        else if (!weapon.gameObject.activeSelf) playerAnimator.SetBool("BigWeapon", false);
    }

    private void ShootStatut()
    {
        if (playerInput.CanShoot) playerAnimator.SetBool("isShooting", true);
        else if (!playerInput.CanShoot) playerAnimator.SetBool("isShooting", false);
    }
}