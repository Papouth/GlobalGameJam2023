using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public int ennemyHealth = 20;

    public bool isAttackingTree = false;

    private void Update() {
        if(ennemyHealth <= 0) {
            Destroy(gameObject);
        }
    }
}