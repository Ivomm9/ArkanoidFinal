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

    Vector2 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {

        float newX = Mathf.Lerp(minX, maxX, slider.value);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

    }

    public void ResetPlayer()
    {
        transform.position = startPosition;
        rigidBody2D.velocity = Vector2.zero;
    }
}
