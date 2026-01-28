using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public GameObject[] animalsPrefabs;
    private float spawnRangeX = 18;
    private float spawnPosZ = 18;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    public float sideSpawnMinZ;
    public float sideSpawnMaxZ;
    public float sideSpawnX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnLeftAnimal", startDelay, spawnInterval + 1f);
        InvokeRepeating("SpawnRightAnimal", startDelay, spawnInterval + 1.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        Vector3 spawnPosX = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        Instantiate(animalPrefabs[animalIndex], spawnPosX, animalPrefabs[animalIndex].transform.rotation);
    }

    void SpawnLeftAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPosZ = new Vector3(-sideSpawnX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
        Vector3 rotation = new Vector3(0, 90, 0);
        Instantiate(animalPrefabs[animalIndex], spawnPosZ, Quaternion.Euler(rotation));
    }

    void SpawnRightAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPosZ = new Vector3(sideSpawnX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
        Vector3 rotation = new Vector3(0, -90, 0);
        Instantiate(animalPrefabs[animalIndex], spawnPosZ, Quaternion.Euler(rotation));
    }


}


