using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    public Rigidbody2D projectile;

    public float moveSpeed = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        projectile = this.gameObject.GetComponent<Rigidbody2D>();  //whatever is attached to gameObject, get the component
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        projectile.velocity = new Vector2(0, 1) * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            ScoreDisplay.instance.AddPoint();
        }

        if (collision.gameObject.name == "Top Bound" || collision.gameObject.name == "Enemy")
        {
            Object.Destroy(this.gameObject);
        }
    }
}
