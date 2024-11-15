using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private List<GameObject> enemyPool;
    private int score = 0;

    public GameObject GetEnemy(GameObject prefab)
    {
        foreach (GameObject enemy in enemyPool)
        {
            if (!enemy.activeSelf)
            {
                enemy.SetActive(true);
                return enemy;
            }
        }
        GameObject newEnemy = Instantiate(prefab);
        enemyPool.Add(newEnemy);
        return newEnemy;
    }

    public void RemoveEnemy(GameObject enemyToRemove)
    {
        enemyToRemove.SetActive(false);
    }

    public void AddPoint()
    {
        score++;
        Debug.Log("Score: " + score);
    }

    public void ResetGame()
    {
        score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
