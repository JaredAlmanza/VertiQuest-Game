using UnityEngine;

public class AmmoCrate : MonoBehaviour
{
    public int ammoAmount = 5;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCombat playerCombat = other.GetComponent<PlayerCombat>();
            if (playerCombat != null)
            {
                playerCombat.IncreaseArrows(ammoAmount);
            }
            Destroy(gameObject); 
        }
    }
}
