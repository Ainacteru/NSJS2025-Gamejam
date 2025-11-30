using System.Collections;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;

    private GameManager gameManager;

    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    IEnumerator spawnEnemy()
    {
        for (int i = 0; i < Mathf.CeilToInt(GameManager.difficulty * 3); i++)
        {
            Vector2 offset = new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
            Instantiate(EnemyToSpawn(), transform.position + (Vector3)offset, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(0.1f, 2f));
        }
    }

    private GameObject EnemyToSpawn()
    {
        float difficulty = Mathf.Clamp(80 * GameManager.difficulty, 0, 100);

        float random = Random.Range(0, 100);

        int enemy;

        if(random < difficulty)
        {
            enemy = 0;
        }
        else
        {
            enemy = 1;
        }

        return enemies[enemy];
    }
}
