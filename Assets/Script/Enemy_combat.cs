using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_combat : MonoBehaviour
{
    public int amount = 1;
    public Transform attackPoint;
    public float weaponRange;
    public LayerMask playerMask;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Use the singleton reference to deal damage
            if (PlayerStat.playerStat != null)
            {
                PlayerStat.playerStat.ChangeHealth(-amount);
            }
        }
    }

    public void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, playerMask);

        if (hits.Length > 0)
        {
            if (PlayerStat.playerStat != null)
            {
                PlayerStat.playerStat.ChangeHealth(-amount);
            }
        }
    }
}
