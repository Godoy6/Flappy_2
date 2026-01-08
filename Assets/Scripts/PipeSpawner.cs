using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public int poolSize = 5;
    public float spawnX = 10f;
    public float distanceBetweenPipes = 5f;
    public float minY = -2f;
    public float maxY = 2f;

    private List<GameObject> pipePool;
    private int currentPipeIndex = 0;

    void Start()
    {
        pipePool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject pipe = Instantiate(pipePrefab);
            pipe.SetActive(false);
            pipePool.Add(pipe);
        }

        // Activar todas al inicio
        for (int i = 0; i < poolSize; i++)
        {
            SpawnPipe();
        }
    }

    void SpawnPipe()
    {
        GameObject pipe = pipePool[currentPipeIndex];

        float randomY = Random.Range(minY, maxY);
        pipe.transform.position = new Vector3(spawnX, randomY, 0);
        pipe.SetActive(true);

        spawnX += distanceBetweenPipes;

        currentPipeIndex++;
        if (currentPipeIndex >= poolSize)
        {
            currentPipeIndex = 0;
        }
    }
}
