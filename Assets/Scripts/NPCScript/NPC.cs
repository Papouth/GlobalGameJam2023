using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class NPC : Interactable
{
    private NavMeshAgent agent;

    private InteractTurret turret;

    private bool isMoving;

    private NPCAssigner assigner;

    private float teleportDistance = 1.5f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        assigner = FindObjectOfType<NPCAssigner>();
    }

    void Update() {
        if(isMoving) {
            if(turret == null) {
                TurretCheck();
            }
        } else {
            moveCheck();
        }
        
    }

    private void moveCheck() {
        if(assigner.grabbedNPC == null) return;

        if(assigner.grabbedNPC.name == name && assigner.turret != null) {

            //transform.LookAt(assigner.turret.teleportPoint);

            agent.destination = getClosestPosition(assigner.turret.teleportPoint.position);

            isMoving = true;
            assigner.turret.busy = true;
        }
    }

    private void TurretCheck() {

        Vector3 npcPosition = transform.position;
        Vector3 destination = assigner.turret.teleportPoint.position;

        if(Vector3.Distance(npcPosition, destination) < teleportDistance) {
            
            transform.position = assigner.turret.turretPoint.position;
            //transform.LookAt(assigner.turret.LookPoint);

            assigner.turret.npcDedans = this;
            assigner.grabbedNPC = null;
            assigner.turret = null;

            isMoving = false;

            turret = assigner.turret;
            agent.enabled = false;
        }
    }

    private Vector3 getClosestPosition(Vector3 destination) {
        NavMeshHit myNavHit;
        if(NavMesh.SamplePosition(destination, out myNavHit, 100, -1)) {
            return myNavHit.position;
        }

        return destination;
    }

    public override void Interact() {
        if(assigner.grabbedNPC == null) {
            Debug.Log("Grabbed NPC");
            assigner.grabbedNPC = this;
        } else if(assigner.grabbedNPC == this) 
            {
            Debug.Log("Ungrabbed NPC");
            assigner.grabbedNPC = null;
        }
    }
}
