using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class EnnemyAttack :MonoBehaviour {

    [SerializeField] private float attackCooldown = 2f;

    private GameObject target;

    private bool playerInRange = false;

    private float attackTime = 0;

    // Start is called before the first frame update
    void Start() {
        target = FindObjectOfType<PlayerMovement>().gameObject;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
             playerInRange = true;
             Debug.Log("in range");
        } else {
            playerInRange = false;
        }
    }

    // Update is called once per frame
    void Update() {
        attackTime += Time.deltaTime;
        if(attackTime > attackCooldown && playerInRange) {
            Debug.Log("Attacked !");

            attackTime = 0;
        }
    }
}