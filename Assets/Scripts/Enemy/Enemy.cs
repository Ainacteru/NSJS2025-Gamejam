using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float health = 20;
    [SerializeField] private float damage = 10;

    private GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        MoveToPlayer();
        CheckHealth();
    }


    private void MoveToPlayer()
    {
        // Calculate the new position
        Vector3 newPosition = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);

        // Apply the new position
        transform.position = newPosition;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, Mathf.Infinity);
        Debug.Log(health);
    }
    private void CheckHealth()
    {
        if(health <= 0)
        {
            //die
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            StartCoroutine(DamageWhileInContact(collision.gameObject));
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            stopDamage = true;
    }

    bool stopDamage = false;

    IEnumerator DamageWhileInContact(GameObject player)
    {
        stopDamage = false;
        
        while (!stopDamage)
        {
            PlayerShoot.playerHealth -= damage;
            yield return new WaitForSeconds(0.5f);
        }
    }

}
