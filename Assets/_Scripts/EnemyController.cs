using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{


    public float verticalSpeed;
    public float verticalBoundary;
    public EnemyManager enemyManager;
    public Lives livesRef;


    // Start is called before the first frame update
    void Start()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
        livesRef = FindObjectOfType<Lives>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();

        if(Time.frameCount % 500 == 0)
        {
            verticalSpeed -= 0.005f;
        }
        Debug.Log(verticalSpeed);
    }

    private void Move()
    {
        transform.position += new Vector3(0.0f, verticalSpeed, 0.0f);
    }

    private void CheckBounds()
    {
        if (transform.position.y < verticalBoundary)
        {
            enemyManager.ReturnEnemy(gameObject);
            if (livesRef.lives > 0)
            {

                livesRef.lives--;
                SoundManagerScript.PlaySound("loseLife");
            }
            else
            {
                SceneManager.LoadScene("End");
            }
        }
    }
}
