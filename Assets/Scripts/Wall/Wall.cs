using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private GameObject borne;
    public InteractWall wallInteract;
    
    // Start is called before the first frame update
    void Start()
    {
        wallInteract = borne.GetComponent<InteractWall>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
