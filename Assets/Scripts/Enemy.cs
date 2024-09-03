using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D enemy;

    public float moveSpeed = 15.0f;

    public bool changeDirection = false;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        enemy = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveEnemy();
        stopEnemy();
    }

    public void moveEnemy()
    {
        if(changeDirection == true)
        {
            enemy.velocity = new Vector2(1, 0) * -1 * moveSpeed;
        }
        else if(changeDirection == false)
        {
            enemy.velocity = new Vector2(1, 0) * moveSpeed;
        }
    }

    public void stopEnemy()
    {
        if (!player.activeInHierarchy)
        {
            this.gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Right Bound")
        {
            Debug.Log("Hit the right wall");
            changeDirection = true;
        }

        if(collision.gameObject.name == "Left Bound")
        {
            Debug.Log("Hit the left wall");
            changeDirection = false;
        }
    }
}
