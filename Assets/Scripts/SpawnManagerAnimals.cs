using UnityEngine;
using System.Collections;

public class SpawnManagerAnimals : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    public void SpawnAnimals(Transform[] spawnPoints, float spawnDelay = 1f)
    {
        int totalAnimals = 20; // spawn excatly 20 animals.
        StartCoroutine(SpawnAnimalsCoroutine(totalAnimals, spawnPoints, spawnDelay));
    }


    private IEnumerator SpawnAnimalsCoroutine(int count, Transform[] spawnPoints, float spawnDelay)
    // Couritne for which spawnpoin to spawn in, which animal in the arrya and the delay for spawning.
    {
        for (int i = 0; i < count; i++)
        {
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            int spawnIndex = Random.Range(0, spawnPoints.Length);

            GameObject spawned = Instantiate(
                animalPrefabs[animalIndex],
                spawnPoints[spawnIndex].position,
                spawnPoints[spawnIndex].rotation
            );

            // Assign GameManager dynamically
            AnimalHealth health = spawned.GetComponent<AnimalHealth>();
            if (health != null)
            {
                health.gameManager = GameObject.FindAnyObjectByType<GameManager>();
            }

            yield return new WaitForSecondsRealtime(spawnDelay);

        }
    }
}

