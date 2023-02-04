using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyFollowPlayer : MonoBehaviour {
    // Start is called before the first frame update
    private GameObject player;

    private void Start() {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    void FixedUpdate() {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();

        agent.destination = player.transform.position;
    } 
}
