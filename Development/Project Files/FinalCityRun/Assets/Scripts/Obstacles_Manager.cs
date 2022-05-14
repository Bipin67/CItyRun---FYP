using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles_Manager : MonoBehaviour
{

    public GameObject[] obstacles;
    public float obstaclesTime;
    private Transform player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(spawnObstacles());
    }

    //
    IEnumerator spawnObstacles()
    {
        yield return new WaitForSeconds(obstaclesTime);
        spawn();
    }

    void spawn()
    {
        int randomObstacles = UnityEngine.Random.Range(0, obstacles.Length - 1);

        float[] xpos = new float[2];
        xpos[0] = 0.27f;
        xpos[1] = 4.5f;

        int RandomXpos = UnityEngine.Random.Range(0, xpos.Length);

        Vector3 spawnPosition = new Vector3(xpos[RandomXpos], 1.2f, player.position.z + 40);
        Instantiate(obstacles[randomObstacles], spawnPosition, obstacles[randomObstacles].transform.rotation);
        StartCoroutine(spawnObstacles());
    }
}


