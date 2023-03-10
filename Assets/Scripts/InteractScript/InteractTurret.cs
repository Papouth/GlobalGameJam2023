using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTurret : Interactable
{
    private NPCAssigner npcassigner;
    
    [SerializeField] public Transform teleportPoint;
    [SerializeField] public Transform turretPoint;

    public bool busy = false; //busy veut dire qu'un PNJ s'y d?place

    public NPC npcDedans = null;


    void Start()
    {
        if(teleportPoint == null) teleportPoint = turretPoint;

        npcassigner = FindObjectOfType<NPCAssigner>();
    }

    public override void Interact() {
        if(npcDedans == null && !busy) {
            npcassigner.turret = this;
            Debug.Log("Turret point activ? !");
        } else {
            Debug.Log("Turret point d?j? occup? !");
        }
    }
}