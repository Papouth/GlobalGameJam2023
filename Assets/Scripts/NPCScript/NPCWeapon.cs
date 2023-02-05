using System.Collections.Generic;
using UnityEngine;

public class NPCWeapon :MonoBehaviour {

    #region Variables
    [SerializeField] public float fireRate = 0.8f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawn;

    private NPC npc;
    public SphereCollider rangeCollider;

    private List<Collider> targetsInRange = new List<Collider>();
    private Collider currentTarget;

    private float timer = 0f;
    #endregion

    private bool canShoot = true;

    #region Builtins
    void Awake() {
        if(rangeCollider == null) rangeCollider = GetComponent<SphereCollider>();
        npc = GetComponentInParent<NPC>();
        
    }

    private void Update() {
        timer += Time.deltaTime;

        if(timer > fireRate) {
            canShoot = true;

            timer = 0;
        }
    }
    #endregion

    #region Actions
    void Shoot(Vector3 where) { //Shoot/aim
        npc.animator.SetTrigger("TriggerTurret");
        
        transform.LookAt(where);

        Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
        
    }
    #endregion

    #region Triggers
    void OnTriggerEnter(Collider other) {

        if(other.CompareTag("Ennemy")) {
            if(!targetsInRange.Contains(other)) {
                targetsInRange.Add(other);
            }
        }
    }

    void OnTriggerStay(Collider other) {
        if(other.CompareTag("Ennemy")) {
            if(targetsInRange.Count > 0
                && (npc.turret != null && !npc.isMoving) ) { //si on est bien dans une tourelle

                    if(canShoot) {
                        determineTarget();
                        Shoot(currentTarget.transform.localPosition);

                        canShoot = false;
                    }
            } else {
                //reset rotation npc
            }
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.CompareTag("Ennemy")) {

           if(targetsInRange.Contains(other)) {
                targetsInRange.Remove(other); 
           }
        }
    }
    #endregion

    #region Fonctions utiles
    void determineTarget() {
        if(targetsInRange.Count > 0) {
            currentTarget = NearestCollider(targetsInRange.ToArray());
        }
    }

    private Collider NearestCollider(Collider[] cols) {
        float nearestInteractable = 9999;
        Collider nearestCol = null;

        foreach(Collider col in cols) {
            if(col == null) continue;

            float currentDistance = Vector3.Distance(col.transform.position, transform.position);
            if(currentDistance <= nearestInteractable) {
                nearestInteractable = currentDistance;
                nearestCol = col;
            }
        }

        return nearestCol;
    }
    #endregion
}
