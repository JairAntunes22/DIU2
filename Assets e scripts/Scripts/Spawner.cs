using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject inimigoPrefab;
    public float spawnRate = 2f;
    private float nextSpawn = 0f;

    // Lista de pontos de spawn
    public Transform[] spawnPoints;

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            SpawnInimigo();
        }
    }

    public void SpawnInimigo()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogWarning("Nenhum ponto de spawn definido no Spawner!");
            return;
        }

        int index = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[index];

        Instantiate(inimigoPrefab, spawnPoint.position, Quaternion.identity);
    }
}
