using System;
using UnityEngine;
using System.Collections.Generic;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private Transform topTile;
    [SerializeField] private GameObject tilePrefab;
    private float tileSpacingY = 15;

    [SerializeField] private Queue<GameObject> tileQueue;
    void Start()
    {
        tileQueue = new Queue<GameObject>();
        for(int i = 0; i < transform.childCount; i++)
        {
            tileQueue.Enqueue(transform.GetChild(i).gameObject);
        }
    }

    void Update()
    {
        float distFromTopTile = Vector2.Distance(Camera.main.transform.position, topTile.position);
        if (distFromTopTile < 15)
        {
            GameObject newTile = Instantiate(tilePrefab, topTile.transform.position + new Vector3 (0, tileSpacingY, 0), Quaternion.identity);
            tileQueue.Enqueue(newTile);
            topTile = newTile.transform;
            topTile.transform.parent = transform;
            GameObject removeTile = tileQueue.Dequeue();
            Destroy(removeTile);
        }
    }
}