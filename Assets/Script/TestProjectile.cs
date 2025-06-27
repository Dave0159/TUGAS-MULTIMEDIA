using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProjectile : MonoBehaviour
{
    public float damage;
    public float knockbackForce = 10f;
    public bool applyKnockback = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Player")
        {
            if (collision.TryGetComponent<EnemyReceiveDamage>(out EnemyReceiveDamage enemy))
            {
                enemy.DealDamage(damage);
            }

            if (applyKnockback && collision.TryGetComponent<Rigidbody2D>(out Rigidbody2D enemyRb))
            {
                Vector2 knockDirection = (collision.transform.position - transform.position).normalized;
                enemyRb.AddForce(knockDirection * knockbackForce, ForceMode2D.Impulse);
            }

            Destroy(gameObject);
        }
    }
}
