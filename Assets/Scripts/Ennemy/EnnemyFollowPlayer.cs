using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyFollowPlayer : MonoBehaviour {
    
    private GameObject player;
    private NavMeshAgent agent;

    private void Start() {
        player = FindObjectOfType<PlayerMovement>().gameObject;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update() 
    {
        //transform.LookAt(new Vector3(player.transform.position.x, 0, player.transform.position.z));
        agent.destination = player.transform.position;
    } 
}