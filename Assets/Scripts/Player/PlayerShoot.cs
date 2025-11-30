using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform boolet;
    [SerializeField] private float shootForce = 50f;
    public static float bulletDamage = 5;
    public static float playerHealth = 100;
    public SceneManagera sceneManagera;

    void Start()
    {
        playerHealth = 100;
        bulletDamage = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            shoot();
        }

        if(playerHealth <= 0)
        {
            sceneManagera.ChangeScene("dead");
            Debug.Log("dieeeee");
        }
    }

    void shoot()
    {
        var bet = Instantiate(boolet, firePoint.transform.position, Quaternion.identity);
        bet.GetComponent<Rigidbody2D>().AddForce(firePoint.transform.up * shootForce, ForceMode2D.Impulse);
    }
}
