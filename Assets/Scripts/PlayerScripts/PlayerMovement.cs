using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    [Header("Player Movement")] 
    public Vector3 directionInput;
    private Vector3 movement;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private float turnSmoothVelocity = 0.1f;
    [SerializeField] private float moveSpeed = 3f;

    [Header("Player Component")]
    private PlayerInput playerInput;
    [SerializeField] private Camera cam;
    private CharacterController cc;
    private Animator animPlayer;
    #endregion


    #region Built In Methods
    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        cc = GetComponent<CharacterController>();
        animPlayer = GetComponent<Animator>();
    }

    private void Update()
    {
        Locomotion();
    }
    #endregion


    #region Movement
    private void Locomotion()
    {
        if (!playerInput) return;

        directionInput.Set(playerInput.MoveInput.x, 0, playerInput.MoveInput.y);

        animPlayer.SetFloat("Movement", directionInput.magnitude); 

        if (directionInput.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(directionInput.x, directionInput.z) * Mathf.Rad2Deg +
                cam.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle,
                ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            directionInput = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        }

        movement = directionInput.normalized * (moveSpeed * Time.deltaTime);
        cc.Move(movement);
    }
    #endregion
}