using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] 
    private GameManager gameManager;

    [SerializeField] 
    private float iniBallSpeed = 10f;

    [SerializeField] 
    private string padTag, verticalWallTag, hotizontalWallTag;

    private float ballSpeed;
    private Vector2 direction;

    void Start()
    {
        direction = new Vector2(1, 1);
        ballSpeed = iniBallSpeed;
    }

    public void Move()
    {
        transform.Translate(direction * ballSpeed * Time.deltaTime);
    }

    private void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == verticalWallTag) 
        {
            direction = new Vector2(direction.x, -direction.y);
        }
        if(collision.gameObject.tag == hotizontalWallTag) 
        {
            direction = new Vector2(-direction.x, direction.y);
            ballSpeed = iniBallSpeed;
            AddPoint();
        }
        if (collision.gameObject.tag == padTag)
        {
            ballSpeed = Random.Range(iniBallSpeed, iniBallSpeed*2);
            direction = new Vector2(-direction.x, Random.Range(-1f, 1f));
        }
    }

    private void AddPoint() 
    {
        if (transform.position.x < 0) 
            gameManager.AddPoint(GameManager.Player.player2);
        else 
            gameManager.AddPoint(GameManager.Player.player1);

        gameManager.ResetBall();
    }
}
