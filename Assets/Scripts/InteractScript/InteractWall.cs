using UnityEngine;

public class InteractWall : Interactable
{
    [SerializeField] private GameObject wall;
    [SerializeField] private int vineNeeded = 5;

    private Player player;

    // Start is called before the first frame update
    void Start() {
        player = FindObjectOfType<Player>();
        wall.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void Interact() {
      if(player.vignes >= vineNeeded) {
            player.vignes -= vineNeeded;

            wall.SetActive(true);
        }
    }

}
