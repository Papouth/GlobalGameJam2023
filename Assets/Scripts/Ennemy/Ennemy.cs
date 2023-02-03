using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    [SerializeField] private int Health = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getHealth() {
        return Health;
    }

    private void decreaseHealth(int health) {
        if(Health - health < 0) {
            Debug.Log("Mort");
        } else Health = health;
    }
}
