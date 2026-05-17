using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public GameObject sword;
    public GameObject bow;
    public Transform bowPoint;
    public GameObject arrowPrefab;
    public Transform attackPoint;
    public float attackRange = 1.5f;
    public LayerMask enemyLayer;
    public bool isBowEquipped = false;
    public Transform cameraTransform;
    public int arrowCount = 10;
    public int keysCollected = 0;


void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            
            if (isBowEquipped && arrowCount > 0)
            {
                ShootArrow();
                AudioManager.Instance.PlaySFX(AudioManager.Instance.arrowShoot);
                animator.SetTrigger("Shoot");

            }
            else if (!isBowEquipped)
            {
                MeleeAttack();
                AudioManager.Instance.PlaySFX(AudioManager.Instance.swordSwing);
                animator.SetTrigger("Sword");

            }
        }

        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            isBowEquipped = !isBowEquipped;
            sword.SetActive(!isBowEquipped);
            bow.SetActive(isBowEquipped);
        }
    }
    public void IncreaseArrows(int amount)
{
    arrowCount += amount;
    Debug.Log("Picked up arrows! Current arrows: " + arrowCount);
}

    void MeleeAttack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);
        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<BossHealth>()?.TakeDamage(2);
        }
    }

     void ShootArrow()
    {
        GameObject arrow = Instantiate(arrowPrefab, bowPoint.position, bowPoint.rotation);
        arrow.GetComponent<Rigidbody>().linearVelocity = bowPoint.forward * 20f;
        arrowCount--;
        Destroy(arrow, 1f);
        
    }

    public void PickUpArrows(int amount)
    {
        arrowCount += amount;
    }

    public void CollectKey()
{
    if (keysCollected < 3)
        keysCollected++;
}
}


