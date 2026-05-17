using UnityEngine;

public class DoorUnlock : MonoBehaviour
{
    public int requiredKeys = 3;
    public GameObject door;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
        PlayerCombat combat = other.GetComponent<PlayerCombat>();
        if (combat != null && combat.keysCollected >= requiredKeys)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.doorOpen);
            Destroy(door);
        }
        }
    }
}