using System.Collections;
using UnityEngine;

public class EnnemyAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private int ennemyDamage = 10;

    private float attackTime = 0;

    private Ennemy ennemy;

    private EnnemyLook ennemyLook;

    private bool canAttack = true;

    private void Start() {
        ennemy = GetComponentInParent<Ennemy>();
    }

    private void Update() {
        attackTime += Time.deltaTime;
        if(attackTime > attackCooldown) {
            canAttack = true;

            attackTime = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Attack(other);
    }

    private void Attack(Collider other) {
        if(!canAttack) return;

        if(other.CompareTag("Player") || other.CompareTag("Arbre") || other.CompareTag("Mur")) {
                switch(other.tag.ToString()) {
                    case "Player": {
                        if(!ennemy.isAttackingTree) other.GetComponent<Player>().playerLife -= ennemyDamage;

                        //Debug.Log("Player life: " + other.GetComponent<Player>().playerLife);
                        break;
                    }

                    case "Arbre": {
                        other.GetComponent<Arbre>().arbreLife -= ennemyDamage;
                        ennemy.isAttackingTree = true;

                        //Debug.Log("Arbre life: " + other.GetComponent<Arbre>().arbreLife);
                        break;
                    }
                }

                ennemy.ennemyLook.target = other.transform.position;
                
            ennemy.animator.SetTrigger("TriggerAttack");

            resetTrigger();

            canAttack = false;

                //Debug.Log("Attacked something");
                attackTime = 0;
        }
    }

    private IEnumerator resetTrigger() {
        yield return new WaitForSeconds(0.3f);
        ennemy.animator.ResetTrigger("TriggerAttack");
    }
}