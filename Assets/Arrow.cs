using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 20;
    public Rigidbody rb;

    void Start()
    {
        rb.linearVelocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<BossHealth>()?.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
