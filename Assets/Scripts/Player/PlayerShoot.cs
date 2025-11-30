using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform boolet;
    [SerializeField] private float shootForce = 50f;
    public static float bulletDamage = 5;
    public static float playerHealth = 100;

    void Start()
    {
        playerHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            shoot();
        }

        if(playerHealth == 0)
        {
            //die
            Debug.Log("dieeeee");
        }
    }

    void shoot()
    {
        var bet = Instantiate(boolet, firePoint.transform.position, Quaternion.identity);
        bet.GetComponent<Rigidbody2D>().AddForce(firePoint.transform.up * shootForce, ForceMode2D.Impulse);
    }
}
