using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        weapon = player.GetComponentInChildren<Weapon>();
    }

    private void Update()
    {
        AddAmmo();
    }

    private void AddAmmo()
    {
        if (playerMovement.inAmmoBox)
        {
            ammoTime += Time.deltaTime;

            if (ammoTime > ammoBoxTimer)
            {
                for (int i = 0; i < player.inventory.Length; i++)
                {
                    weapon.magazineCount = weapon.magazineCountBase;
                }

                playerMovement.inAmmoBox = false;
            }
        }
    }

    public override void Interact()
    {
        playerMovement.inAmmoBox = true;
    }
}