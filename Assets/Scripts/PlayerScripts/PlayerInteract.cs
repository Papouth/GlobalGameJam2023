using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    #region Variables
    private PlayerInput playerInput;
    #endregion

    #region Built In Methods
    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        Interact();
    }
    #endregion

    #region Interact
    private void Interact()
    {
        if (playerInput.CanInteract)
        {
            Debug.Log("Interact pressed");
            playerInput.CanInteract = false;
        }
    }
    #endregion
}