using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack :MonoBehaviour {

    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private float attackRange = 2f;

    [SerializeField] private GameObject target;

    private bool isAvailable = true;

    private bool attacked;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if(isAvailable) {
            if(Vector3.Distance(GetComponent<Transform>().position, target.transform.position) < attackRange) {
                Debug.Log("attacked");
                StartCoroutine(StartCooldown());
            }
        }
    }

    public IEnumerator StartCooldown() {
        isAvailable = false;
        yield return new WaitForSeconds(attackCooldown);
        isAvailable = true;
    }
}