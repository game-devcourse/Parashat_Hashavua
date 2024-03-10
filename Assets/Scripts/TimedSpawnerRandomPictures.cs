using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

/**
 * This component instantiates a given prefab at random time intervals and random bias from its object position.
 */
public class TimedSpawnerRandomPictures: MonoBehaviour {
    [SerializeField] private GameObject[] prefabs;

    [Tooltip("Minimum time between consecutive spawns, in seconds")] [SerializeField] float minTimeBetweenSpawns = 0.2f;
    [Tooltip("Maximum time between consecutive spawns, in seconds")] [SerializeField] float maxTimeBetweenSpawns = 1.0f;

    void Start() {
        this.StartCoroutine(SpawnRoutine());    // co-routines
    }

    IEnumerator SpawnRoutine() {    // co-routines
        while (true) {
            float timeBetweenSpawnsInSeconds = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            yield return new WaitForSeconds(timeBetweenSpawnsInSeconds);       // co-routines
            
            //select a random prefeb to spawn
            int randomIndex = Random.Range(0, prefabs.Length);
            GameObject prefabToSpawn = prefabs[randomIndex];

            GameObject newObject = Instantiate(prefabToSpawn.gameObject, transform.position, Quaternion.identity);
        }
    }
}