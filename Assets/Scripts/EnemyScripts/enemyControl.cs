using UnityEngine;

public class enemyControl : MonoBehaviour
{
    // ── Referencias ────────────────────────────────────────
    public spawner spawner;
    public GameObject target;
    public enemyIdle idleState;
    public enemyAttack attackState;
    public enemyChasing chasingState;

    // ── Stats ──────────────────────────────────────────────
    public int speed = 3;
    public float attackRange = 1.5f;
    public float detectionRange = 8f;
    public float attackCooldown = 1.5f;

    // ── Estado interno ─────────────────────────────────────
    int health;
    float cooldownTimer;
    public bool esJefe;

    void Start()
    {
        target = GameObject.FindWithTag("Player");
        if (gameObject.tag.Equals("Jefe"))
        {
            health = 10;
            esJefe = true;
        }
        else if (gameObject.tag.Equals("Enemigo Normal"))
        {
            health = 3;
            esJefe = false;
        }
    }

    public void TakeDamage(int amount)
    {
        health += amount;
        if (health <= 0)
        {
            if (spawner != null && spawner.isJefe())
                spawner.setJefe(false);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (target == null) return;

        if (cooldownTimer > 0)
            cooldownTimer -= Time.deltaTime;

        ControlStates();
    }

    void ControlStates()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist > detectionRange)
        {
            idleState.Idle();
            return;
        }
        
        if ((dist > attackRange || !esJefe) && dist < detectionRange )
        {
            Debug.Log("Persiguiendo");
            chasingState.Chase();
            return;
        }

        // Solo el jefe ataca con cooldown (dispara balaLogica).
        // Normales y pequeños matan por OnTriggerEnter.
        if (cooldownTimer <= 0 && dist < attackRange && esJefe)
        {
            Debug.Log("Atacando");
            cooldownTimer = attackCooldown;
            attackState.Attack(target.transform);
        }
    }
}