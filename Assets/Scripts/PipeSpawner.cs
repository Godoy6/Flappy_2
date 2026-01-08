using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public static PipeSpawner instance;

    public GameObject pipePrefab;
    public Transform player;

    public int poolSize = 5;
    public float forwardOffset = 20f;
    public float distanceBetweenPipes = 6f;
    public float minY = -2f;
    public float maxY = 2f;

    private List<GameObject> pool;
    private float nextSpawnZ;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        pool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject pipe = Instantiate(pipePrefab);
            pipe.SetActive(false);   //  SIEMPRE false
            pool.Add(pipe);
        }
    }

    void Start()
    {
        nextSpawnZ = player.position.z + forwardOffset;

        // Spawnea las primeras tuberías
        for (int i = 0; i < poolSize; i++)
        {
            GetPipe();
        }
    }

    public GameObject GetPipe()
    {
        foreach (GameObject pipe in pool)
        {
            if (!pipe.activeInHierarchy)
            {
                float randomY = Random.Range(minY, maxY);

                //  POSICIONAR PRIMERO
                pipe.transform.position = new Vector3(
                    player.position.x,
                    randomY,
                    nextSpawnZ
                );

                //  ACTIVAR DESPUÉS
                pipe.SetActive(true);

                nextSpawnZ += distanceBetweenPipes;
                return pipe;
            }
        }
        return null;
    }
}
