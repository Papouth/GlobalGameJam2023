using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEnd : MonoBehaviour
{
    public Arbre arbre;

    private void Start()
    {
        arbre = FindObjectOfType<Arbre>();  
    }

    private void Update()
    {
       if (arbre.arbreLife <= 0)
        {
            SceneManager.LoadScene("Xblaze");
        }
    }
}