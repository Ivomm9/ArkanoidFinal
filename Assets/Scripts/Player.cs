using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Necesario para usar UI como Slider

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;
    public Slider slider;
    public GameObject RightLerp;
    public GameObject LeftLerp;
    public float minX;
    public float maxX;

    // Referencia a la bola
    public GameObject ball;

    Vector2 startPosition;

    void Start()
    {
        Time.timeScale = 1;
        minX = LeftLerp.transform.position.x;
        maxX = RightLerp.transform.position.x;
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
