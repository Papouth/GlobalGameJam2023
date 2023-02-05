using UnityEngine;

public class InteractWall : Interactable
{
    [SerializeField] private GameObject wall;
    [SerializeField] private int vineNeeded = 5;

    [SerializeField] public int maxLife = 25;

    public int wallLife = 0;
    private Player player;

    // Start is called before the first frame update
    void Start() {
        player = FindObjectOfType<Player>();
        wall.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       if(wallLife <= 0) {
            wall.SetActive(false);
        }
    }

    public override void Interact() {
      if(player.vignes >= vineNeeded) {
            player.vignes -= vineNeeded;

            wall.SetActive(true);

            wallLife = maxLife;
        }
    }

}
