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
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Vector3 targetPos;
    [HideInInspector] public bool inAmmoBox;
    [HideInInspector] public bool dead;

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
        cam = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        MouseAim();

        if (!inAmmoBox || !dead) Locomotion();
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

    private void MouseAim()
    {
        if (!playerInput) return;

        Ray ray = cam.ScreenPointToRay(playerInput.MousePosInput);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            targetPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.LookAt(targetPos);
        }
    }
    #endregion
}