﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float horizontalSpeed;
    public float horizontalBoundary;

    public float direction;
    public EnemyManager enemyManager;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
        SpawnEnemy();

    }

    private void Move()
    {
        transform.position += new Vector3(horizontalSpeed * direction * Time.deltaTime, 0.0f, 0.0f);
    }

    private void CheckBounds()
    {
        if(transform.position.x >= horizontalBoundary)
        {
            direction = -1.0f;
        }

        if (transform.position.x <= -horizontalBoundary)
        {
            direction = 1.0f;
        }

    }

    private void SpawnEnemy()
    {
        if (Time.frameCount % Random.Range(200, 700) == 0)
        {
            enemyManager.GetEnemy(transform.position);
        }
    }



}
