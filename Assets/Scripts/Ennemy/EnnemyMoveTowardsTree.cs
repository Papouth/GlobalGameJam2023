using UnityEngine;
using UnityEngine.AI;

public class EnnemyMoveTowardsTree : MonoBehaviour
{
    private Ennemy ennemy;
    private Player player;

    private Arbre arbre;
    private Vector3 destination;

    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        ennemy = GetComponent<Ennemy>();
        agent = GetComponent<NavMeshAgent>();

        player = FindObjectOfType<Player>();
        arbre = FindObjectOfType<Arbre>();
    }

    // Update is called once per frame
    void Update()
    {
        if(destination != default(Vector3)) return;

        if(player.playerLife <= 0) {
            Debug.Log("Trying to move towards the tree");
            destination = getClosestPosition(arbre.transform.position);
            agent.destination = destination;
        }
    }

    private Vector3 getClosestPosition(Vector3 destination) {
        NavMeshHit myNavHit;
        if(NavMesh.SamplePosition(destination, out myNavHit, 100, -1)) {
            return myNavHit.position;
        }

        return destination;
    }
}
