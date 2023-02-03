using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour {
    // Start is called before the first frame update
    [SerializeField] private GameObject player;

    void FixedUpdate() {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();

        agent.destination = player.transform.position;
    } 
}
