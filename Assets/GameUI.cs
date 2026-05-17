using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameUI : MonoBehaviour
{
    public TMP_Text healthText;
    public TMP_Text arrowText;
    public TMP_Text weaponText;
    public TMP_Text keysText;
    public TMP_Text bossHealthText;

    public PlayerCombat playerCombat;
    public PlayerHealth playerHealth;
    public BossHealth bossHealth;
 
    void Update()
    {
        if (playerHealth != null)
            healthText.text = "Health: " + playerHealth.GetCurrentHealth();

        if (playerCombat != null)
        {
            arrowText.text = "Arrows: " + playerCombat.arrowCount;
            weaponText.text = "Weapon: " + (playerCombat.isBowEquipped ? "Bow" : "Sword");
            keysText.text = "Keys: " + playerCombat.keysCollected + "/3";
        }

        if (bossHealth != null)
        {
            bossHealthText.text = "Boss Health: " + bossHealth.GetCurrentHealth();
        }
    }
}
