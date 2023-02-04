using System.Collections;
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
    [SerializeField] private int spawnDelay = 10;

    [SerializeField] private GameObject[] spawners;
    [SerializeField] private GameObject enemy;
    #endregion

    #region variables
    private bool isCooldown;
    public bool inWave;
    private int nextWaveMobs;
    private int currentWave = 0;
    private int needSpawn;

    private float time = 0;
    #endregion

    #region Unity built-ins
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

        time += Time.deltaTime;

        if(time > spawnDelay && needSpawn > 0) {
            Instantiate(enemy, pickRandomSpawner(), Quaternion.identity);
            needSpawn--;

            time = 0f;
        }
    }
    #endregion

    #region START/END WAVE

    private void startWave() {

        currentWave++;
        int needSpawn = nextWaveMobs;

        Debug.Log("Spawning wave #" + currentWave + " with " + needSpawn + " mobs");

        Debug.Log("Début de la vague");

        //StartCoroutine(spawnWave());

        inWave = true;
    }

    private void endWave() {
        inWave = false;

        nextWaveMobs += eachWave;

        Debug.Log("Fin de la vague");

        StartCoroutine(StartCooldown());
    }
    #endregion

    #region Fonctions

    private Vector3 pickRandomSpawner() {
        return spawners[Random.Range(0, spawners.Length)].transform.position;
    }


    private bool seeIfTheyAreAllDead() {
        Scene scene = SceneManager.GetActiveScene();

        foreach(GameObject obj in scene.GetRootGameObjects()) {
            if(obj.GetComponent<Ennemy>() != null) {
                return false;
            }
        }

        return true;
    }

    private IEnumerator StartCooldown() {
        isCooldown = true;
        yield return new WaitForSeconds(timeBetweenWaves);
        isCooldown = false;
    }

    #endregion
}
