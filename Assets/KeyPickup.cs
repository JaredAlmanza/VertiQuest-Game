using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCombat combat = other.GetComponent<PlayerCombat>();
            if (combat != null)
            {
                combat.CollectKey();
                AudioManager.Instance.PlaySFX(AudioManager.Instance.keyPickup);
                Destroy(gameObject);
            }
        }
    }
}
