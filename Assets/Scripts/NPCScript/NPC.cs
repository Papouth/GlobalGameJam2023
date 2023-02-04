using UnityEngine;
using UnityEngine.AI;

public class NPC : Interactable {

    #region Variables
    private NavMeshAgent agent;
    private NPCAssigner assigner;

    public float teleportDistance = 1.5f;

    public InteractTurret turret;
    public bool isMoving;
    #endregion

    #region Built-ins
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        assigner = FindObjectOfType<NPCAssigner>();
    }

    void Update() {
        if(isMoving) {
            if(turret == null) {
                TurretTeleportCheck();
            }
        } else {
            moveCheck();
        }

        /*
        if(!isMoving && turret != null) {
            TurretAI();
        }
        */
    }
    #endregion


    #region Checks AI
    private void TurretAI() {
        
    }

    private void moveCheck() {
        if(assigner.grabbedNPC == null || turret != null) return;

        if(assigner.grabbedNPC.name == name && assigner.turret != null) {

            //transform.LookAt(assigner.turret.teleportPoint);

            agent.destination = getClosestPosition(assigner.turret.teleportPoint.position);

            isMoving = true;
            assigner.turret.busy = true;
        }
    }

    private void TurretTeleportCheck() {

        Vector3 npcPosition = transform.position;
        Vector3 destination = assigner.turret.teleportPoint.position;

        if(Vector3.Distance(npcPosition, destination) < teleportDistance) {
            
            transform.position = assigner.turret.turretPoint.position;
            //transform.LookAt(assigner.turret.LookPoint);

            isMoving = false;

            turret = assigner.turret;
            agent.enabled = false;

            assigner.turret.npcDedans = this;
            assigner.grabbedNPC = null;
            assigner.turret = null;
        }
    }

    
    private Vector3 getClosestPosition(Vector3 destination) {
        NavMeshHit myNavHit;
        if(NavMesh.SamplePosition(destination, out myNavHit, 100, -1)) {
            return myNavHit.position;
        }

        return destination;
    }
    #endregion

    #region Interactable
    public override void Interact() 
    {
        if(assigner.grabbedNPC == null) 
        {
            Debug.Log("Grabbed NPC");
            assigner.grabbedNPC = this;
        } 
        else if(assigner.grabbedNPC == this) 
        {
            Debug.Log("Ungrabbed NPC");
            assigner.grabbedNPC = null;
        }
    }
    #endregion
}
