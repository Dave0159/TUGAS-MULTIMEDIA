using System.Collections;
using UnityEngine;

public class EnemyShooting : EnemyAttack
{
    public GameObject projectile;
    public float minDamage;
    public float maxDamage;
    public float projectileForce;
    public float cooldown;

    public override void Start()
    {
        base.Start();
        StartCoroutine(ShootPlayer());
    }

    IEnumerator ShootPlayer()
    {
        yield return new WaitForSeconds(cooldown);

        if (player != null)
        {
            GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);

            if (spell.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb))
            {
                Vector2 direction = (player.transform.position - transform.position).normalized;
                rb.velocity = direction * projectileForce;
            }

            if (spell.TryGetComponent<TestEnemyProjectile>(out TestEnemyProjectile tp))
            {
                tp.amount = Random.Range(minDamage, maxDamage);
            }
        }

        StartCoroutine(ShootPlayer());
    }
}
