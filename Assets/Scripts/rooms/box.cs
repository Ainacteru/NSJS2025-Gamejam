using System;
using Unity.Mathematics;
using UnityEngine;

public class box : MonoBehaviour
{

    [SerializeField] private GameObject[] doors;
    [SerializeField] private GameObject start;

    [SerializeField] private float spawnRadius;
    [SerializeField] private GameObject spawner;
    private float enemiesRemaining;

    void Awake()
    {
        foreach (var door in doors)
        {
            door.AddComponent<door>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        enemiesRemaining = GameObject.FindGameObjectsWithTag("Enemy").Length;

    }

    public void startRoom()
    {
        Debug.Log($"Room {gameObject.name} has started!");
        roomLock();
        startSpawners();
    }

    private void roomDone()
    {
        foreach(var door in doors)
        {
            door.GetComponent<door>().Open();
        }
    }

    private void roomLock()
    {
        foreach(var door in doors)
        {
            door.GetComponent<door>().Close();
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

            Instantiate(spawner, worldSpawnPos, Quaternion.identity);


        }


    }
}
