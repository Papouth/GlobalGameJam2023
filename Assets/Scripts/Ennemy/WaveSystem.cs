using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VFX;

public class WaveSystem : MonoBehaviour
{
    #region Parametres
    [SerializeField] private int numberOfWaves = 10;
    [SerializeField] private int baseMonsters = 20;
    [SerializeField] private int eachWave = 5; //pas de nom pour la variable désolééé

    [SerializeField] private int timeBetweenWaves = 5;
    [SerializeField] private int spawnDelay = 2;

    [SerializeField] private GameObject[] spawners;
    [SerializeField] private GameObject enemy;
    #endregion

    private bool isCooldown = false;

    private int nextWaveMobs;

    private int currentWave = 0;

    private int needSpawn;

    public bool inWave = false;

    // Start is called before the first frame update
    void Start() 
    {
        nextWaveMobs = baseMonsters;
    }

    // Update is called once per frame
    void Update()
    {
        if(!inWave && !isCooldown) {
            startWave();
        }

        if(inWave && seeIfTheyAreAllDead()) {
            endWave();
        }
    }

    private Vector3 pickRandomSpawner() {
        System.Random random = new System.Random();

        return spawners[random.Next(spawners.Length)].transform.position;
    }

    private void startWave() {

        currentWave++;
        int needSpawn = nextWaveMobs;

        Debug.Log("Spawning wave #"+currentWave+" with "+needSpawn+" mobs");

        Debug.Log("Début de la vague");

        StartCoroutine(spawnWave());

        inWave = true;
    }
    private void endWave() {
        inWave = false;

        nextWaveMobs += eachWave;

        Debug.Log("Fin de la vague");

        StartCoroutine(StartCooldown());
    }


    private bool seeIfTheyAreAllDead() {
        UnityEngine.SceneManagement.Scene scene = SceneManager.GetActiveScene();

        foreach(GameObject obj in scene.GetRootGameObjects()) {
            if(obj.GetComponent<Ennemy>() != null) {
                return false;
            }
        }

        return true;
    }

    private IEnumerator spawnWave() {
        for(int i = 0; i < needSpawn; i++) {
            Instantiate(enemy, pickRandomSpawner(), Quaternion.identity);

            //SPAWN ENNEMY

            yield return new WaitForSeconds(3);
        }
    }

    private IEnumerator StartCooldown() {
        isCooldown = true;
        yield return new WaitForSeconds(timeBetweenWaves);
        isCooldown = false;
    }
}
