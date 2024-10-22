using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;
    public float speed = 300;
    private Vector2 velocity;

    Vector2 startPosition;
    void Start()
    {
        startPosition = transform.position;

        ResetBall();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            FindObjectOfType<GameManager>().LoseLive();
        }
    }

    public void ResetBall()
    {
        transform.position = startPosition;
        rigidBody2D.velocity = Vector2.zero;

        // Inicia la corrutina que espera 2 segundos antes de aplicar la fuerza
        StartCoroutine(DelayedStart());
    }

    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(2); // Espera 2 segundos

        velocity.x = Random.Range(-1, 1);
        velocity.y = 1;
        rigidBody2D.AddForce(velocity * speed);
    }

}
