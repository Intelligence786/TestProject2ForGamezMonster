using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float horizontalSpeed = 10f;
    private float verticalSpeed = 10f;

    bool isDead = false;

    void IncreaseSpeed()
    {
        verticalSpeed = verticalSpeed + 1f;
    }

    void Start()
    {
        InvokeRepeating("IncreaseSpeed", 15, 15);
    }

    public float HorizontalSpeed { get => horizontalSpeed; set => horizontalSpeed = value; }

    public delegate void End(Ball ball);
    public End EndEvent;

    void Move()
    {
        float horizontalDir = Input.GetKey(KeyCode.UpArrow) ? verticalSpeed : -verticalSpeed;
        transform.position = new Vector2(transform.position.x + HorizontalSpeed * Time.deltaTime, transform.position.y + horizontalDir * Time.deltaTime);
    }

    void FixedUpdate()
    {
        if (!isDead)
            Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            isDead = true;
            ObstacleCollision();
        }
    }

    private void ObstacleCollision()
    {
        EndEvent(this);
    }
}
