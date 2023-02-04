using UnityEngine;

public class InteractVigne : Interactable
{
    [SerializeField] private Transform spawnFruit;
    [SerializeField] private GameObject prefabFruit;
    [SerializeField] private float tempsDePousse = 15;

    private float timer;

    private GameObject spawnedFruit;

    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnedFruit != null) return;

        timer += Time.deltaTime;

        if(timer >= tempsDePousse) {
            Debug.Log("Poussé !");
            spawnedFruit = Instantiate(prefabFruit, spawnFruit);

            timer = 0;
        }
    }

    public override void Interact() {
        if(spawnedFruit != null) {
            player.vignes += 1;
            Destroy(spawnedFruit);
        }
    }
}
