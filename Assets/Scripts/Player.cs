using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Necesario para usar UI como Slider

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;
    public Slider slider;
    public float minX = -1.875f;
    public float maxX = 1.875f;

    // Referencia a la bola
    public GameObject ball;

    Vector2 startPosition;

    void Start()
    {
        GameManager.instance.player = this;
        startPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            GameManager.instance.ToggleAutoPlay();
        }
        // Si el AutoPlay está activado, seguir la posición de la bola
        if (GameManager.instance.isAutoPlayEnabled)
        {
            AutoPlay();
        }
        else
        {
            // Control normal con el slider
            float newX = Mathf.Lerp(minX, maxX, slider.value);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }

    public void ResetPlayer()
    {
        transform.position = startPosition;
        rigidBody2D.velocity = Vector2.zero;
    }


    void AutoPlay()
    {
        if (ball != null)
        {

            float ballX = ball.transform.position.x;


            float newX = Mathf.Clamp(ballX, minX, maxX);


            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }
}
