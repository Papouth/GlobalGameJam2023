using System.Collections;
using UnityEngine;

public class EnnemyAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private int ennemyDamage = 10;

    private float attackTime = 0;

    private Ennemy ennemy;

    private EnnemyLook ennemyLook;

    private bool attacked = false;

    private void Start() {
        ennemy = GetComponentInParent<Ennemy>();
    }

    private void onTriggerEnter(Collider other) {
        if(!attacked) Attack(other);
    }

    private void OnTriggerStay(Collider other)
    {
        Attack(other);
    }

    private void Attack(Collider other) {
        if(attacked) ennemy.animator.ResetTrigger("TriggerAttack");

        if(other.CompareTag("Player") || other.CompareTag("Arbre") || other.CompareTag("Mur")) {
            attackTime += Time.deltaTime;
            if(attackTime > attackCooldown) {
                switch(other.tag.ToString()) {
                    case "Player": {
                        if(!ennemy.isAttackingTree) other.GetComponent<Player>().playerLife -= ennemyDamage;

                        Debug.Log("Player life: " + other.GetComponent<Player>().playerLife);
                        break;
                    }

                    case "Arbre": {
                        other.GetComponent<Arbre>().arbreLife -= ennemyDamage;
                        ennemy.isAttackingTree = true;

                        Debug.Log("Arbre life: " + other.GetComponent<Arbre>().arbreLife);
                        break;
                    }
                }

                ennemy.ennemyLook.target = other.transform.position;
                ennemy.animator.SetTrigger("TriggerAttack");

                StartCoroutine(resetTrigger());

                Debug.Log("Attacked something");
                attackTime = 0;
            }
        }
    }

    private IEnumerator resetTrigger() {
        yield return new WaitForSeconds(1f);
        ennemy.animator.ResetTrigger("TriggerAttack");
    }
}