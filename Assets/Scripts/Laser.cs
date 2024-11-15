using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 15f;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // Desactiva el láser si sale de la pantalla
        if (transform.position.y > 10)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false); // Desactiva el enemigo
            gameObject.SetActive(false); // Desactiva el láser
            GameManager.Instance.AddPoint(); // Aumenta la puntuación
        }
    }
}
