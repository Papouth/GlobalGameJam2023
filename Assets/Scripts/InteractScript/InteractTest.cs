using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTest : Interactable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public override void Interact() {
        base.Interact();
        Debug.Log("Bj ma gueule");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
