using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    [SerializeField] private float currentTime = 0f;
    [SerializeField] private float spawnRate = 0f;

    [SerializeField] private GameObject animalPrefab = null;
    [SerializeField] private GameObject icebergGameObject = null;
    [SerializeField] private Transform spawnArea = null;

    // Start is called before the first frame update
    void Start()
    {
        RestartTimers();
    }

    // Update is called once per frame
    void Update()
    {
        float timeToSpawn = currentTime + spawnRate;

        if(Time.time < timeToSpawn) { return; }

        SpawnAnimal();
        RestartTimers();

    }

    private void SpawnAnimal()
    {
        int horizontalSpan = (int)spawnArea.localScale.x / 2;
        int verticalSpan = (int)spawnArea.localScale.y / 2;
        int randomHorizontal = Random.Range(-horizontalSpan, horizontalSpan + 1);
        int randomVertical = Random.Range(-verticalSpan, verticalSpan + 1);
        
        Vector2 spawnPosition = new Vector2(randomHorizontal, randomVertical);

        

        if (icebergGameObject.GetComponent<MeshCollider>().bounds.Contains(spawnPosition))
        {
            SpawnAnimal();
        }
        else
        {
            GameObject animalInstance = Instantiate(animalPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private void RestartTimers()
    {
        currentTime = Time.time;
        spawnRate = Random.Range(3, 7);
    }


}
