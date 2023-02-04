using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public int ennemyHealth = 20;

    private void Update() {
        if(ennemyHealth <= 0) {
            Destroy(gameObject);
        }
    }
}