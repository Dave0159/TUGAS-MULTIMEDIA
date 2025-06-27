using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public GameObject projectile;
    public float minDamage;
    public float maxDamage;
    public float projectileForce;
    public float manaUsage = 10f; // Biaya mana per spell

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            // Pastikan pemain memiliki cukup mana sebelum meluncurkan spell
            if (PlayerStat.playerStat.mana >= manaUsage)
            {
                // Kurangi mana dari pemain
                PlayerStat.playerStat.ManaCost(manaUsage);

                // Buat spell
                GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);

                if (spell.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb))
                {
                    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector2 myPos = transform.position;
                    Vector2 direction = (mousePos - myPos).normalized;
                    rb.velocity = direction * projectileForce;
                }

                if (spell.TryGetComponent<Projectile>(out Projectile tp))
                {
                    tp.damage = Random.Range(minDamage, maxDamage);
                }
            }
            else
            {
                Debug.Log("Tidak cukup mana untuk menggunakan spell!");
            }
        }
    }
}
