using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void Interact();
}

public abstract class Interactable : MonoBehaviour, IInteractable
{
    public virtual void Interact() {

        
    }
}