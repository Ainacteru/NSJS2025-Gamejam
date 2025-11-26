using UnityEngine;

public class Enemy : MonoBehaviour
{

    private void MoveToPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        Vector2 playerPos = player.transform.position;
        Vector2 pos = transform.position;



    }
}
