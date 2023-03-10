using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemy : MonoBehaviour
{
    public int ennemyHealth = 20;

    public NavMeshAgent agent;

    public Animator animator;

    public bool isAttackingTree = false;

    public EnnemyLook ennemyLook;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        ennemyLook = GetComponent<EnnemyLook>();
    }

    private void Update() {
        if(agent.destination != default(Vector3)) {
            animator.SetFloat("EnemyMove", 0.5f);
        } else {
            animator.SetFloat("EnemyMove", 0.0f);
        }

        if(ennemyHealth <= 0) {
            Destroy(gameObject);
        }
    }
}