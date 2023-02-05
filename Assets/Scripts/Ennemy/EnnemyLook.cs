using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyLook : MonoBehaviour 
{
    private Ennemy ennemy;
    public float RotationSpeed;

    //values for internal use
    private Quaternion _lookRotation;
    private Vector3 _direction;

    public Vector3 target;

    private void Start() {
        ennemy = GetComponent<Ennemy>();
    }

    void Update() {
        if(target != default(Vector3)){
            transform.LookAt(target);
        }
    }

    void rotateTowards(Vector3 destination) {
        //find the vector pointing from our position to the target
        _direction = (ennemy.agent.destination - transform.position).normalized;

        //create the rotation we need to be in to look at the target
        _lookRotation = Quaternion.LookRotation(_direction);

        //rotate us over time according to speed until we are in the required rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
    }
}
