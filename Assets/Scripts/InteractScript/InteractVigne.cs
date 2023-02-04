using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using UnityEngine;

public class InteractVigne : Interactable
{
    [SerializeField] private Transform spawnFruit;
    [SerializeField] private GameObject prefabFruit;
    [SerializeField] private float tempsDePousse = 15;

    private float timer;

    private GameObject spawnedFruit;

    // Start is called before the first frame update
    void Start()
    {

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
            Destroy(spawnedFruit);
        }
    }
}
