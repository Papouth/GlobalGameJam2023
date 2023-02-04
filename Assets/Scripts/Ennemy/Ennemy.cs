using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ennemy : MonoBehaviour
{
    [SerializeField] private int Health = 20;

    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerMovement>().gameObject;
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
