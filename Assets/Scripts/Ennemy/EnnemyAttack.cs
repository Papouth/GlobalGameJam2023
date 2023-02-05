using UnityEngine;

public class EnnemyAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private int ennemyDamage = 10;

    private float attackTime = 0;

    private Ennemy ennemy;

    private void Start() {
        ennemy = GetComponentInParent<Ennemy>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Arbre") || other.CompareTag("Mur"))
        {
            attackTime += Time.deltaTime;
            if (attackTime > attackCooldown)
            {
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

                    case "Mur": {
                        other.GetComponent<Wall>().wallInteract.wallLife -= ennemyDamage;

                        ennemy.lastAttackedWall = other.GetComponent<Wall>().wallInteract;

                        ennemy.agent.destination = transform.position;
                        break;
                    }
                }

                Debug.Log("Attacked something");
                attackTime = 0;
            }
        }
    }
}