using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyFollowPlayer : MonoBehaviour {
    
    private GameObject player;
    public NavMeshAgent agent;

    public Ennemy ennemy;

    private float timer = 0;
    public float consciousness = 3;
    public float distance = 3;

    public float procheDuJoueur = 3f;

    private Vector3 lastPosition;

    private void Start() {
        player = FindObjectOfType<PlayerMovement>().gameObject;
        agent = GetComponent<NavMeshAgent>();
        ennemy = GetComponent<Ennemy>();
    }

    void Update() 
    {
        if(player.GetComponent<Player>().playerLife <= 0) return;

        if(Vector3.Distance(transform.position, lastPosition) < procheDuJoueur) {
            agent.SetDestination(player.transform.position);
            
            return;
        }
        
        timer += Time.deltaTime;
        if(timer >= consciousness) {
            timer = 0;

            lastPosition = player.transform.position;

            agent.SetDestination(player.transform.position);
        }
        
        if(Vector3.Distance(transform.position, lastPosition) < distance) {
            agent.SetDestination(player.transform.position);
        }
        //transform.LookAt(new Vector3(player.transform.position.x, 0, player.transform.position.z));
    } 
}