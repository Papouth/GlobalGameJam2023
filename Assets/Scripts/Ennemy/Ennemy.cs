using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    [SerializeField] private int health = 20;


    public int getHealth() 
    {
        return health;
    }

    public void decreaseHealth(int damage) 
    {
        if (health - damage <= 0) Destroy(gameObject);
    }
}