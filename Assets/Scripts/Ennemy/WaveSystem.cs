using System.Collections;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    #region Variables
    [Header("Paremeters")]
    [SerializeField] private int baseMonsters = 20;
    [SerializeField] private int eachWave = 5; //pas de nom pour la variable désolééé

    [SerializeField] private float timeBetweenWaves = 5;
    [SerializeField] private float spawnDelay = 3;

    [SerializeField] private int baseSpecialPerWave = 1 ;
    [SerializeField] private int specialsPerWave    = 1 ;
    [SerializeField] private int specialsStartWave  = 2 ;

    [SerializeField] private GameObject[] spawners;
    [SerializeField] private GameObject enemy;

    [SerializeField] private GameObject[] specials = new GameObject[2];


    private bool isCooldown;
    public bool inWave;

    private int currentWave = 2;
    private int needSpawn = 0;
    private int neededSpecials = 0;

    private float timeForSpawn = 0;

    #endregion

    #region Unity built-ins

    void Update()
    {
        timeForSpawn += Time.deltaTime;

        if(timeForSpawn > spawnDelay && needSpawn > 0) {
            //Debug.Log("spawning");

            if(neededSpecials > 0) {
                Instantiate(pickRandomSpecial(), pickRandomSpawner(), Quaternion.identity);
                
                neededSpecials -= 1;
            }

            Instantiate(enemy, pickRandomSpawner(), Quaternion.identity);

            needSpawn--;

            timeForSpawn = 0f;
        }

        if(!inWave && !isCooldown) {
            startWave();
        }

        if(inWave && DeathChecker() && needSpawn == 0) {
            endWave();
        }
    }
    #endregion

    #region START/END WAVE

    private void startWave() {
        currentWave++;

        needSpawn = baseMonsters + (eachWave * currentWave);

        if(currentWave >= specialsStartWave) {
            neededSpecials = baseSpecialPerWave + (specialsPerWave * currentWave);
        }

        Debug.Log("Spawning wave #" + currentWave + " with " + needSpawn + " mobs");

        inWave = true;
    }

    private void endWave() {
        inWave = false;

        Debug.Log("Fin de la vague");

        StartCoroutine(StartCooldown());
    }
    #endregion

    #region Fonctions

    private GameObject pickRandomSpecial() {
        return specials[Random.Range(0, specials.Length)];
    }

    private Vector3 pickRandomSpawner() {
        return spawners[Random.Range(0, spawners.Length)].transform.position;
    }

    private bool DeathChecker() {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag("Ennemy");

        return ennemies.Length == 0;
    }

    private IEnumerator StartCooldown() {
        isCooldown = true;
        yield return new WaitForSeconds(timeBetweenWaves);
        isCooldown = false;
    }

    #endregion
}