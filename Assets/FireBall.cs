using UnityEngine;

public class Fireball : MonoBehaviour
{
    public int damage = 10;
    public GameObject Fireballl;

    [System.Obsolete]
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>()?.TakeDamage(damage);
            Destroy(gameObject);
        }
    
    }

    
}
