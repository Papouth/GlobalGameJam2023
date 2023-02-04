using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public int ennemyHealth = 20;


    public void decreaseHealth(int damage) 
    {
        if (ennemyHealth - damage <= 0) Destroy(gameObject);
        ennemyHealth -= damage;
    }
}