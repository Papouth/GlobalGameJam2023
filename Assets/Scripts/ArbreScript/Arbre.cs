using UnityEngine;

public class Arbre : MonoBehaviour
{
    public int arbreLife = 250;

    public bool arbreMort = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!arbreMort && arbreLife <= 0) {
            //perdu
            Debug.Log("Arbre détruit");
            arbreMort = true;
        }
    }
}
