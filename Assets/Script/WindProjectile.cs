using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindProjectile : MonoBehaviour
{
    public float damage;
    public float knockbackForce = 10f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            
            if (other.TryGetComponent<EnemyReceiveDamage>(out EnemyReceiveDamage health))
            {
                health.DealDamage(damage);
            }

            // Beri efek knockback jika musuh punya Rigidbody2D
            if (other.TryGetComponent<Rigidbody2D>(out Rigidbody2D enemyRb))
            {
                Vector2 knockDirection = (other.transform.position - transform.position).normalized;
                enemyRb.AddForce(knockDirection * knockbackForce, ForceMode2D.Impulse);
            }

            // Hancurkan spell setelah mengenai target
            Destroy(gameObject);
        }
    }
}
