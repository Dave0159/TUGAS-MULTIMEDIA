using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpell : MonoBehaviour
{
    public SpellManager spellManager;
    public float minDamage;
    public float maxDamage;
    public float projectileForce;
    public float manaUsage;
    public float castCooldown = 1f;

    private float lastCastTime = -999f;

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && Time.time - lastCastTime >= castCooldown)
        {
            if (PlayerStat.playerStat.mana >= manaUsage)
            {
                PlayerStat.playerStat.ManaCost(manaUsage);

                GameObject spellPrefab = spellManager.CurrentSpell;
                GameObject spell = Instantiate(spellPrefab, transform.position, Quaternion.identity);

                if (spell.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb))
                {
                    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector2 myPos = transform.position;
                    Vector2 direction = (mousePos - myPos).normalized;
                    rb.velocity = direction * projectileForce;
                }

                if (spell.TryGetComponent<TestProjectile>(out TestProjectile tp))
                {
                    tp.damage = Random.Range(minDamage, maxDamage);

                    // Cek apakah ini spell angin
                    if (spell.name.Contains("Wind")) 
                    {
                        tp.applyKnockback = true;
                        tp.knockbackForce = 10f;
                    }
                    else
                    {
                        tp.applyKnockback = false;
                    }
                }

                lastCastTime = Time.time;
            }
            else
            {
                Debug.Log("Tidak cukup mana untuk menggunakan spell!");
            }
        }
    }
}
