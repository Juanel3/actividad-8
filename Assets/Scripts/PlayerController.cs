using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public GameObject laserPrefab;
    public int laserPoolSize = 10;
    private List<GameObject> laserPool;
    private int currentLaserIndex = 0;

    void Start()
    {
        InitializeLaserPool();
    }

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireLaser();
        }
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0, 0);
        transform.Translate(movement * speed * Time.deltaTime);

        // Limitar movimiento del jugador en los bordes de la pantalla
        float clampedX = Mathf.Clamp(transform.position.x, -8, 8);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

    private void InitializeLaserPool()
    {
        laserPool = new List<GameObject>();
        for (int i = 0; i < laserPoolSize; i++)
        {
            GameObject laser = Instantiate(laserPrefab);
            laser.SetActive(false);
            laserPool.Add(laser);
        }
    }

    private void FireLaser()
    {
        GameObject laser = laserPool[currentLaserIndex];
        laser.transform.position = transform.position + Vector3.up * 1.5f;
        laser.SetActive(true);

        currentLaserIndex = (currentLaserIndex + 1) % laserPoolSize;
    }
}
