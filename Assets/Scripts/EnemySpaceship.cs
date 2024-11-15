using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceship : MonoBehaviour
{
    [SerializeField] float speed;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.down * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Laser"))
        {
            // Desactiva el enemigo y el láser tras el choque
            GameManager.Instance.RemoveEnemy(gameObject);
            collision.gameObject.SetActive(false);
            GameManager.Instance.AddPoint();
        }
        else if (collision.CompareTag("Player"))
        {
            // Reinicia el juego si el enemigo choca con el jugador
            GameManager.Instance.ResetGame();
        }
    }
}
