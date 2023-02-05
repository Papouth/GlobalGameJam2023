using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemy : MonoBehaviour
{
    public int ennemyHealth = 20;

    public NavMeshAgent agent;

    public bool isAttackingTree = false;

    public InteractWall lastAttackedWall = null; //sert à savoir si on a besoin de se déplacer

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        if(lastAttackedWall != null) {
            if(lastAttackedWall.wallLife <= 0) {
                lastAttackedWall = null;
            }
        }

        if(ennemyHealth <= 0) {
            Destroy(gameObject);
        }
    }
}