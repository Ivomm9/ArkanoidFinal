using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int brickHealth;
    public Sprite[] healthSprites;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        GameManager.instance.bricks++;
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            GameManager.instance.AddPoints(this);
            brickHealth--;

            if (brickHealth <= 0)
            {
                GameManager.instance.AddPoints(this);

                GameManager.instance.bricks--;
                Destroy(gameObject);
                GameManager.instance.CheckLevelCompleted();
            }
            else if (brickHealth == 2)
            {
                StartCoroutine(DuplicateBallScale(collision.gameObject));
                UpdateBrickSprite();
            }
            else
            {
                UpdateBrickSprite();
            }

        }
    }

    private void UpdateBrickSprite()
    {
        // Cambiar el sprite según el valor de brickHealth
        switch (brickHealth)
        {
            case 1:
                spriteRenderer.sprite = healthSprites[0]; 
                break;
            case 2:
                spriteRenderer.sprite = healthSprites[1]; 
                break;
            case 3:
                spriteRenderer.sprite = healthSprites[2]; 
                break;
        }
    }

    private IEnumerator DuplicateBallScale(GameObject ball)
    {
        Vector3 originalScale = ball.transform.localScale;
        ball.transform.localScale = originalScale * 2; 

        yield return new WaitForSeconds(8); 

        ball.transform.localScale = originalScale; 
    }
}
