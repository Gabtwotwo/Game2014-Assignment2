using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{


    public float verticalSpeed;
    public float verticalBoundary;
    public BulletManager bulletManager;
    public EnemyManager enemyManager;
    public Score scoreRef;

    // Start is called before the first frame update
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
        enemyManager = FindObjectOfType<EnemyManager>();
        scoreRef = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {

       enemyManager.ReturnEnemy(collider.gameObject);
       scoreRef.score++;
        SoundManagerScript.PlaySound("destroyEnemy");
        
    }


    private void _Move()
    {
        transform.position += new Vector3(0.0f, verticalSpeed, 0.0f);
    }

    private void _CheckBounds()
    {
        if (transform.position.y > verticalBoundary)
        {
            bulletManager.ReturnBullet(gameObject);
        }
    }
}
