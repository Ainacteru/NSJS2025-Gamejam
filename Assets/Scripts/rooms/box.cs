using System;
using UnityEngine;

public class box : MonoBehaviour
{

    [SerializeField] private GameObject[] doors;
    private float enemiesRemaining;

    void Awake()
    {
        foreach (var door in doors)
        {
            door.AddComponent<door>();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //spawn enemies
        //close
    }

    // Update is called once per frame
    void Update()
    {
        enemiesRemaining = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
}
