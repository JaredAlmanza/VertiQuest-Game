using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{
    public Transform player;
    public Animator animator;
    public float detectionRange = 15f; 
    public float attackRange = 10f; 
    public float meleeRange = 3f; 
    public float moveSpeed = 3f;
    public GameObject fireballPrefab; 
    public Transform fireballSpawnPoint; 
    public float fireballSpeed = 10f;
    public float attackCooldown = 2f; 

    private NavMeshAgent agent;
    private bool isPlayerDetected = false;
    private bool canAttack = true;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        
        isPlayerDetected = distanceToPlayer <= detectionRange;

        if (isPlayerDetected)
        {
            AudioManager.Instance.PlayMusic(AudioManager.Instance.bossMusic);
            if (distanceToPlayer > attackRange)
            {
                
                agent.SetDestination(player.position);
            }
            else
            {
                
                agent.ResetPath();
                AttackPlayer(distanceToPlayer);
            }
        }
    }

    void AttackPlayer(float distanceToPlayer)
    {
        if (canAttack)
        {
            if (distanceToPlayer <= meleeRange)
            {
                StartCoroutine(MeleeAttack());
            }
            else
            {
                StartCoroutine(RangedAttack());
                animator.SetTrigger("Shoot");
            }
        }
    }

    System.Collections.IEnumerator MeleeAttack()
    {
        canAttack = false;
        Debug.Log("Boss performs melee attack!");

        

        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    System.Collections.IEnumerator RangedAttack()
    {
        canAttack = false;
        AudioManager.Instance.PlaySFX(AudioManager.Instance.fireballShoot);

        GameObject fireball = Instantiate(fireballPrefab, fireballSpawnPoint.position, Quaternion.identity);
        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        Vector3 direction = (player.position - fireballSpawnPoint.position).normalized;
        rb.linearVelocity = direction * fireballSpeed;

        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
