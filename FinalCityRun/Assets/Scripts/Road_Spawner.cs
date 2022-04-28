using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road_Spawner : MonoBehaviour
{
    

    public GameObject[] roadPrefab;

    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private float roadLeangth = 13.0f;
    private int amnRoadOnScreen = 10;
    private float safeZone = 15.0f;
    private List<GameObject> activeRoad;
    public int lastPrefabIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        activeRoad = new List<GameObject>();
        //get the player transform
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
       // road on screen spawn
        for (int i = 0; i < amnRoadOnScreen; i++)
        {
            //spawn the first 2 normalroad
            if (i < 2)
                SpawnRoad(0);
            else
                SpawnRoad();
            
        } 
    }

    // Update is called once per frame
    void Update()
    {
        // roads spawn after first 7 tiles are spawned
        if(playerTransform.position.z - safeZone > spawnZ - amnRoadOnScreen * roadLeangth)
        {
            SpawnRoad();
            DeleteRoad();
        }
    }

    private  void SpawnRoad(int prefabIndex = -1)
    {
        GameObject go;
        // if the prefab index is -1 then randomize the prefab 
        if(prefabIndex == -1)
        {
            // randomize the prefab index
            go = Instantiate(roadPrefab[RandomPrefabIndex()]) as GameObject;
        }
        else
        {
            // else use the prefab index
            go = Instantiate(roadPrefab[prefabIndex]) as GameObject;
        }
        // set the spawn position
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        // add the road to the active road list
        spawnZ += roadLeangth;
        activeRoad.Add(go);
    } 


    // delete the road that is not on screen
    private void DeleteRoad()
    {
        // if the road list is not empty
        Destroy(activeRoad[0]);
        // remove the road from the list
        activeRoad.RemoveAt(0);
    }


    // randomize the prefab index
    private int RandomPrefabIndex()
    {
        // if the last prefab index is the same as the current prefab index then randomize the prefab index
        if (roadPrefab.Length <= 1)
        {
            // if there is only one prefab then return the prefab index
            return 0;
        }
        // else return the prefab index
        int randomIndex = lastPrefabIndex;
        // while the random index is the same as the last prefab index
        while (randomIndex == lastPrefabIndex)
        {
            // randomize the prefab index
            randomIndex = Random.Range(0, roadPrefab.Length);
        }
        // set the last prefab index
        lastPrefabIndex = randomIndex;
        // return the prefab index
        return randomIndex;
    }


}
