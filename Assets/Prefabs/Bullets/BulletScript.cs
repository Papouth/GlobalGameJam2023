using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    #region Variables
    [SerializeField] private int bulletDamage;
    [SerializeField] private float bulletSpeed;
    private Rigidbody rb;
    #endregion


    #region Built In Methods
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Moove();
    }
    #endregion


    #region Functions
    private void Moove()
    {
        rb.velocity = transform.forward * bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ennemy"))
        {
            // On r�cup�re la vie de mon ennemi et on lui enl�ve le nombre de d�gats de la balle
            other.GetComponent<Ennemy>().ennemyHealth -= bulletDamage;
        }
    }
    #endregion
}