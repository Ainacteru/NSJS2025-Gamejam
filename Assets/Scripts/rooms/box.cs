using UnityEngine;

public class box : MonoBehaviour
{

    [SerializeField] private door[] doors;
    [SerializeField] private GameObject start;

    [SerializeField] private float spawnRadius;
    [SerializeField] private GameObject spawner;
    [SerializeField] float enemiesRemaining;
    private bool roomStart = false;

    // Update is called once per frame
    void Update()
    {
        enemiesRemaining = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if(roomStart && enemiesRemaining == 0)
        {
            roomDone();
        }
    }

    public void startRoom()
    {
        Debug.Log($"Room {gameObject.name} has started!");
        roomLock();
        startSpawners();
        roomStart = true;
    }

    private void roomDone()
    {
        foreach(var door in doors)
        {
            door.Open();
            
            Debug.Log($"Room {name} is complete!");
        }
        GameManager.difficulty *= 1.2f;
        GameManager.roomsBeaten++;
        Destroy(this);
    }

    private void roomLock()
    {
        foreach(var door in doors)
        {
            door.Close();
            Debug.Log($"Room {name} has locked!");
        }
    }

    public void startSpawners()
    {
        float spawnerAmount = GameManager.difficulty * 3;

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
