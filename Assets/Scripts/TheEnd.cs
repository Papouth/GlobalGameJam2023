using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEnd : MonoBehaviour
{
    public Arbre arbre;
    private float timeFin;
    private float timerFin;

    private void Start()
    {
        arbre = FindObjectOfType<Arbre>();
        timerFin = 300f;
    }

    private void Update()
    {
        if (arbre.arbreLife <= 0)
        {
            SceneManager.LoadScene("Xblaze");
        }

        timeFin += Time.deltaTime;
        if (timeFin > timerFin)
        {
            SceneManager.LoadScene("Xblaze");
        }
    }
}