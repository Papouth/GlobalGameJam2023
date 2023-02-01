using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    #region Variables
    private Vector2 moveInput;
    #endregion


    #region Bool Functions
    public Vector2 MoveInput => moveInput;
    #endregion


    #region Functions
    public void OnMovement(InputValue value)
    {
        // On récupère la valeur du mouvement qu'on stock dans un Vector2
        moveInput = value.Get<Vector2>();
    }
    #endregion
}