using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    #region Variables
    private Vector2 moveInput;
    private Vector2 wheelInput;
    private Vector2 mousePosInput;
    private bool canInteract;
    private bool canShoot;

    #endregion


    #region Bool Functions
    public Vector2 MoveInput => moveInput;

    public Vector2 WheelInput => wheelInput;

    public Vector2 MousePosInput => mousePosInput;

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
        moveInput = value.Get<Vector2>();
    }

    public void OnWheel(InputValue value)
    {
        wheelInput = value.Get<Vector2>();
    }

    public void OnMousePosition(InputValue value)
    {
        mousePosInput = value.Get<Vector2>();
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