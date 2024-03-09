using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipespawner : MonoBehaviour
{

    [SerializeField] private Pipes pipes;
    [SerializeField] private float spawnTime;
    
    
    
    void Start()
    {
        StartCoroutine(SpawnPipe());
    }

    
    void Update()
    {
        
    }

    private IEnumerator SpawnPipe()
    {
        while (Application.isPlaying)
        {
            Instantiate(pipes, new Vector3(transform.position.x, transform.position.y + Random.Range(-1.5f, 1.5f), transform.position.z), Quaternion.identity, transform);
            yield return new WaitForSeconds(spawnTime);
        }
        
    }
}
