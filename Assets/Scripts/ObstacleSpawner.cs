using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public GameObject colorChangerPrefab;
    public GameObject starPrefab;
    public float spawnInterval = 5f;
    public float spawnNextY = 10f;
    public Transform ball;

    void Update()
    {
        if (ball.position.y + 10f > spawnNextY)
        {
            SpawnNext();
            spawnNextY += spawnInterval;
        }
    }

    private void SpawnNext()
    {
        // Random Obstacle
        int index = Random.Range(0, obstaclePrefabs.Length);
        Vector3 spawnPos;
        if (index == 1)
        {
            spawnPos = new Vector3(-1f, spawnNextY, 0f);
        }
        else
        {
            spawnPos = new Vector3(0f, spawnNextY, 0f);
        }

        Instantiate(obstaclePrefabs[index], spawnPos, Quaternion.identity);
        if (index == 0)
        {
            Instantiate(starPrefab, spawnPos, Quaternion.identity);
        }

        // Color Changer
        float verticalSpacingAboveObstacle = 3f;
        Vector3 ccPos = new Vector3(0f, spawnPos.y + verticalSpacingAboveObstacle, 0f);

        Instantiate(colorChangerPrefab, ccPos, Quaternion.identity);
    }
}
