using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public GameObject colorChangerPrefab;
    public GameObject starPrefab;
    public float spawnInterval = 8f;
    public float spawnNextY = 16f;
    public Transform ball;

    void Update()
    {
        if (ball.position.y + 16f > spawnNextY)
        {
            SpawnNext();
            spawnNextY += spawnInterval;
            Debug.Log(BallColor.score);
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
        if (BallColor.score % 2 == 0 && BallColor.score != 0)
        {
            Vector3 ccPos = new Vector3(0f, spawnNextY + 4f, 0f);
            Instantiate(colorChangerPrefab, ccPos, Quaternion.identity);
        }
    }
}
