using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class InteractAmmoBox : Interactable
{
    [SerializeField] private Player player;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Weapon weapon;
    [SerializeField] private float ammoBoxTimer;
    private float ammoTime = 0f;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        AddAmmo();
    }

    private void AddAmmo()
    {
        if (playerMovement.inAmmoBox)
        {
            // Set trigger anim interact
            player.playerAnimator.SetTrigger("Interact");

            ammoTime += Time.deltaTime;

            if (ammoTime > ammoBoxTimer)
            {
                for (int i = 0; i < player.inventory.Length; i++)
                {
                    if (player.inventory[i].transform.childCount != 0)
                    {
                        weapon = player.GetComponentInChildren<Weapon>();

                        weapon.magazineCount = weapon.magazineCountBase;
                    }
                }

                // Reset trigger anim interact
                player.playerAnimator.ResetTrigger("Interact");

                playerMovement.inAmmoBox = false;

                ammoTime = 0;
            }
        }
    }

    public override void Interact()
    {
        playerMovement.inAmmoBox = true;
    }
}