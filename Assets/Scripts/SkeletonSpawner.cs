using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSpawner : MonoBehaviour
{
    [SerializeField] float spawnRate = 2f;
    [SerializeField] GameObject Skeleton;
    [SerializeField] GameObject spawnpoint;


    // Start is called before the first frame update
    void Start()
    {


        InvokeRepeating("SpawnSkeleton", 2f, spawnRate);

    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnSkeleton()
    {

        Instantiate(Skeleton, spawnpoint.gameObject.transform.position, Quaternion.identity);

    }

}
