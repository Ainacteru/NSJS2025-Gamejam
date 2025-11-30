using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public static float bossHealth;
    [SerializeField] private float spawnRadius;
    [SerializeField] private GameObject spawner;
    private bool bossActive = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bossHealth = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        while(bossActive && bossHealth > 0)
        {
            startBoss();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    void startBoss()
    {
        float rand = Random.Range(0, 5);
        switch(rand)
        {
            case 0:
                StartCoroutine(SpawnSpawners());
                return;
            default:
                return;
        }
    }

    IEnumerator SpawnSpawners()
    {
        for (int i = 0; i < Random.Range(1, 10); i++)
        {
            startSpawners();
            yield return new WaitForSeconds(Random.Range(0.5f, 2f));
        }
    }

    private void startSpawners()
    {
        float spawnerAmount = GameManager.difficulty * 5;

        for (int i = 0; i < spawnerAmount; i++)
        {
            float angle = i * Mathf.PI * 2f / spawnerAmount;
            
            Vector2 localCircleOffset = new Vector2(Mathf.Cos(angle) * spawnRadius,Mathf.Sin(angle) * spawnRadius);

            Vector3 worldSpawnPos = transform.TransformPoint(localCircleOffset);

            Vector3 offset = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5));

            Instantiate(spawner, worldSpawnPos + offset, Quaternion.identity);
            Debug.Log($"Original pos{worldSpawnPos}");
            Debug.Log($" new pos {worldSpawnPos + offset}");

        }
    }
}
