using UnityEngine;

public class bollet : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 5f);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(PlayerShoot.bulletDamage);
        }

        Destroy(gameObject);
    }
}