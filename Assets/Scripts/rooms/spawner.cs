using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < (GameManager.difficulty * 3); i++)
        {
            Instantiate(EnemyToSpawn(), transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private GameObject EnemyToSpawn()
    {
        float difficulty = 80 * GameManager.difficulty ;

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
