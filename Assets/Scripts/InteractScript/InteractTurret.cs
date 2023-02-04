using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTurret : Interactable
{
    private NPCAssigner npcassigner;
    
    [SerializeField] public Transform teleportPoint;
    [SerializeField] public Transform turretPoint;
    [SerializeField] public Transform LookPoint;

    public bool busy = false; //busy veut dire qu'un PNJ s'y déplace

    public NPC npcDedans = null;

    // Start is called before the first frame update
    void Start()
    {
        if(teleportPoint == null) teleportPoint = turretPoint;

        npcassigner = FindObjectOfType<NPCAssigner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact() {
        if(npcDedans == null && !busy) {
            npcassigner.turret = this;
            Debug.Log("Turret point activé !");
        } else {
            Debug.Log("Turret point déjà occupé !");
        }

    }
}
