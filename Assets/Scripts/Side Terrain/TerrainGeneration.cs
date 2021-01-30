using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
    //[SerializeField] private const int length = 100;
    [SerializeField] private const int scanRadius = 2;

    [SerializeField] Transform terrainContainer = null;
    [SerializeField] private GameObject terrainPrefab = null;

    [SerializeField] private int averageHeight = 0; //the average height that increases every pre-determined interval
    private float tolerance = 0.5f; //the height to be added to the average height
    private const int width = 16; //the length of the screen
    private const int reserve = 3;
    private const int resolution = 10;

    private float[] heightMap = new float[(width + reserve) * resolution];
    private GameObject[] heightGOs = new GameObject[(width + reserve) * resolution];

    private void Start()
    {
        for (int i = 0; i < width * 2; i++)
        {
            heightMap[i] = UnityEngine.Random.Range(1, tolerance) + (float)averageHeight;

            GameObject gameObject = Instantiate(terrainPrefab, terrainContainer);
            heightGOs[i] = gameObject;

            TransformGOs(i);
        }
    }

    private void TransformGOs(int i)
    {   
        GameObject gameObject = heightGOs[i];
        if (i < width * resolution) { gameObject.SetActive(true); } //move this somewhere
        gameObject.transform.localScale = new Vector3((1 / resolution), heightMap[i], 1);
        gameObject.transform.position = new Vector3();
    }

    private void Update()
    {

    }


}
