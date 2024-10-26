using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;
    public float speed = 75;
    private Vector2 velocity;

    Vector2 startPosition;
    void Start()
    {
        GameManager.instance.ball = this;
        startPosition = transform.position;

        ResetBall();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            GameManager.instance.LoseLive();
            SoundManager.instance.PlaySound(SoundManager.instance.loseLife);
        }
        else
        {
            SoundManager.instance.PlaySound(SoundManager.instance.bounce);
        }
        if (rigidBody2D.velocity.magnitude <= 11)
        {
            rigidBody2D.velocity *= 1.01f;
 
        }

        float hitPoint = (transform.position.x - collision.transform.position.x);
        Vector2 direction = new Vector2(hitPoint, 1).normalized;


    }

    public void ResetBall()
    {
        transform.position = startPosition;
        rigidBody2D.velocity = Vector2.zero;

        StartCoroutine(DelayedStart());
    }

    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(2); 

        velocity.x = Random.Range(-1.0f, 1.0f);
        velocity.y = 1;
        rigidBody2D.AddForce(velocity * speed);
    }

}
