using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerInteract : MonoBehaviour
{
    #region Variables
    private PlayerInput playerInput;
    public float radius;
    public LayerMask interactableLayer;
    public Transform interactionPoint;

    private int interactableCount;
    private Interactable interactable;

    public Collider[] colliders = new Collider[5];
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
            Detector();
            playerInput.CanInteract = false;
        }
    }
    #endregion

    public virtual void Detector()
    {
        interactableCount = Physics.OverlapSphereNonAlloc(interactionPoint.position, radius, colliders, interactableLayer);

        if (interactableCount > 0)
        {
            interactable = NearestCollider(colliders);

            if (interactable != null)
            {
                interactable.Interact();
            }
        }

        playerInput.CanInteract = false;
        interactable = null;
    }

    private Interactable NearestCollider(Collider[] cols)
    {
        float nearestInteractable = 9999;
        Collider nearestCol = null;

        foreach (Collider col in cols)
        {
            if (col == null) continue;

            float currentDistance = Vector3.Distance(col.transform.position, transform.position);
            if (currentDistance <= nearestInteractable)
            {
                nearestInteractable = currentDistance;
                nearestCol = col;
            }
        }
        if (nearestCol.GetComponent(typeof(Interactable)) != null)
        {
            return nearestCol.GetComponent<Interactable>();
        }
        else return null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(interactionPoint.position, radius);
    }
}