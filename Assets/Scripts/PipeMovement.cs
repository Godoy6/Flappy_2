using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float despawnZ = -10f;
    public Transform player;

    void Update()
    {
        if (transform.position.z < player.position.z + despawnZ)
        {
            gameObject.SetActive(false);
            PipeSpawner.instance.GetPipe();
        }
    }
}
