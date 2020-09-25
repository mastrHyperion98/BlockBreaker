using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;
using UnityEngine.Scripting;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    private float upperYBound;
    private float lowerYBound;
    private float leftXBound;
    private float rightXBound;
    private float blockWidth;
    private float blockHeight;
    [Range(1,10)]
    public int r;
    [Range(1,10)]
    public int aliveThreshold;
    [Range(1,10)]
    public int deathThreshold;
    [Range(1, 100)]
    public int initialOdds;
    private int[,] map;
    [SerializeField] private GameObject block;
    private GameObject emptyHolder;
    void Awake()
    {
        Camera main = Camera.main;
        blockWidth = block.GetComponent<SpriteRenderer>().bounds.size.x;
        blockHeight = block.GetComponent<SpriteRenderer>().bounds.size.y;
        rightXBound = main.ViewportToWorldPoint(new Vector3(1,0,0)).x-blockWidth/2.0f;
        leftXBound = blockWidth/2.0f;
        upperYBound = main.ViewportToWorldPoint(new Vector3(0,1,0)).y - blockHeight/2.0f;
        lowerYBound = main.ViewportToWorldPoint(new Vector3(0, 0.3f, 0)).y;
    }

    private void Start()
    {
        int num_occurences = r;
        map = NewMap();
        InitMap();
        do
        {
            map = Generate();
            num_occurences--;
        } while (num_occurences > 0);
                    
        emptyHolder =new GameObject();
        for (int x = 0; x < map.GetLength(0); x++)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                if (map[x, y] == 1)
                {
                    Vector3 position = new Vector3(leftXBound + (x*blockWidth), upperYBound - (y*blockHeight),0.0f);
                    Instantiate(block,position, block.transform.rotation, emptyHolder.transform);
                }
            }
        }
    }

    private void Update()
    {
    }

    private int[,] Generate()
    {
        int numXBlocks = Mathf.FloorToInt((rightXBound - leftXBound) / blockWidth);
        int numYBlocks = Mathf.FloorToInt((upperYBound - lowerYBound) / blockHeight);
        int[,] newMap = NewMap();
        int neighb;
        BoundsInt myB = new BoundsInt(-1, -1, 0, 3, 3, 1);


        for (int x = 0; x < numXBlocks; x++) {
            for (int y = 0; y < numYBlocks; y++) {
                neighb = 0;
                foreach (var b in myB.allPositionsWithin)
                {
                    if (b.x == 0 && b.y == 0) continue;
                    if (x+b.x >= 0 && x+b.x < numXBlocks && y+b.y >= 0 && y+b.y <numYBlocks) 
                        neighb += map[x + b.x, y + b.y];
                    else
                        neighb++;
                }

                if (map[x,y] == 1) {
                    if (neighb < deathThreshold) 
                        newMap[x, y] = 0;
                    else 
                        newMap[x, y] = 1;
                }
                if (map[x,y] == 0) {
                    if (neighb > aliveThreshold)
                        newMap[x, y] = 1;
                    else
                        newMap[x, y] = 0;
                }
            }
        }
        return newMap;
    }
    private void InitMap() {
        for (int x = 0; x < map.GetLength(0); x++)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                map[x, y] = Random.Range(1, 101) < initialOdds ? 1 : 0;
            }
        }
    }
    private int[,] NewMap()
    {
        if(emptyHolder != null)
            Destroy(emptyHolder.gameObject);
        int numXBlocks = Mathf.FloorToInt((rightXBound - leftXBound) / blockWidth);
        int numYBlocks = Mathf.FloorToInt((upperYBound - lowerYBound) / blockHeight);
        return new int[numXBlocks,numYBlocks];
    }

}
