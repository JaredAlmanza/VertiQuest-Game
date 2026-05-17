using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider playerHealthBar;
    public Text arrowCountText;
    private PlayerHealth playerHealth;
    private PlayerCombat playerCombat;

    [System.Obsolete]
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        playerCombat = FindObjectOfType<PlayerCombat>();
    }

    void Update()
    {
        playerHealthBar.value = playerHealth.CurrentHealth;
        arrowCountText.text = "Arrows: " + playerCombat.arrowCount;
    }
}
