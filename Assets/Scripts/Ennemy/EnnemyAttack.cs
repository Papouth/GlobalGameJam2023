using System;
using System.Collections;
using UnityEngine;

public class EnnemyAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private int ennemyDamage = 10;

    private float attackTime = 0;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            attackTime += Time.deltaTime;
            if (attackTime > attackCooldown)
            {
                other.GetComponent<Player>().playerLife -= ennemyDamage;
                Debug.Log("slt à tous ça attaque");
                attackTime = 0;
            }
        }
    }
}