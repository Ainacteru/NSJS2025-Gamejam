using System.Collections;
using TMPro;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public static float bossHealth;

    [Header("Spawner Settings")]
    [SerializeField] private float spawnRadius = 10f;
    [SerializeField] private GameObject spawner;

    [Header("Boss Settings")]
    [SerializeField] private Transform player;
    [SerializeField] private float dashForce = 15f;

    [SerializeField] private TMP_Text bossHealthTxt;
    public SceneManagera sceneManagera;

    private bool bossStarted = false;
    private Rigidbody2D rb;
    public float moveSpeed = 10;

    private void Start()
    {
        bossHealth = 1000;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (bossStarted == false && bossHealth > 0)
            return;

        if(bossStarted)
        {
            bossHealthTxt.gameObject.SetActive(true);
        }
        bossHealthTxt.text = bossHealth.ToString();

        if(bossHealth >= 0)
        {
            sceneManagera.ChangeScene("win");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Bullet hits ONLY deal damage
        if (collision.CompareTag("Bullet"))
        {
            bossHealth -= PlayerShoot.bulletDamage;
            return;
        }

        // Player triggers the fight
        if (collision.CompareTag("Player") && bossStarted == false)
        {
            bossStarted = true;
            bossHealthTxt.gameObject.SetActive(true);

            Debug.Log("Boss Activated!");

            // Boss should now collide physically
            GetComponent<Collider2D>().isTrigger = false;

            StartCoroutine(BossLoop());
        }

        if(collision.CompareTag("Player") && bossStarted)
        {
            PlayerShoot.playerHealth -= 20;
        }
    }
  
    private IEnumerator BossLoop()
    {
        while (bossHealth > 0)
        {
            yield return StartCoroutine(PerformBossAction());
        }

        Debug.Log("Boss Defeated!");
    }    
    private IEnumerator PerformBossAction()
    {
        int rand = Random.Range(0, 5);

        MoveToPlayer();
        switch (rand)
        {   
            case 0:
                yield return StartCoroutine(SpawnSpawners());
                break;
            case 1:
                Dash();
                yield return new WaitForSeconds(1f);
                break;
            default:
                yield return new WaitForSeconds(1f);
                break;
        }
    }

    private void MoveToPlayer()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * moveSpeed;
    }

    private void Dash()
    {
        if (player == null)
        {
            Debug.LogWarning("Player reference missing!");
            return;
        }

        Vector2 direction = (player.position - transform.position).normalized;
        rb.AddForce(direction * dashForce, ForceMode2D.Impulse);

        Debug.Log("Boss Dash!");
    }
    private IEnumerator SpawnSpawners()
    {
        int spawnBursts = Random.Range(1, 10);

        for (int i = 0; i < spawnBursts; i++)
        {
            SpawnSpawnerRing();
            yield return new WaitForSeconds(Random.Range(0.5f, 2f));
        }
    }

    private void SpawnSpawnerRing()
    {
        float spawnerAmount = GameManager.difficulty * 5;

        for (int i = 0; i < spawnerAmount; i++)
        {
            float angle = i * Mathf.PI * 2f / spawnerAmount;

            Vector2 localOffset = new Vector2(
                Mathf.Cos(angle) * spawnRadius,
                Mathf.Sin(angle) * spawnRadius
            );

            // Correct world-position calculation
            Vector3 worldPos = transform.position + (Vector3)localOffset;

            Instantiate(spawner, worldPos, Quaternion.identity);
            Debug.Log("Spawner!");
        }
    }

}
