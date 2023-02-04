using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    #region Variables
    private Vector2 moveInput;
    private bool canInteract;
    private bool canShoot;

    #endregion


    #region Bool Functions
    public Vector2 MoveInput => moveInput;

    public bool CanInteract
    {
        get { return canInteract; }
        set { canInteract = value; }
    }

    public bool CanShoot
    {
        get { return canShoot; }
        set { canShoot = value; }
    }
    #endregion


    #region Functions
    public void OnMovement(InputValue value)
    {
        // On récupère la valeur du mouvement qu'on stock dans un Vector2
        moveInput = value.Get<Vector2>();
    }

    public void OnInteract()
    {
        canInteract = true;
    }

    public void OnShoot()
    {
        canShoot = true;
    }

    public void OnStopShoot()
    {
        canShoot = false;
    }
    #endregion
}