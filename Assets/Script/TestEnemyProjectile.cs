using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyProjectile : MonoBehaviour
{
  public float amount;

  void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.tag != "Enemy")
    {
        if(collision.tag == "player")
        {
           PlayerStat.playerStat.ChangeHealth(amount);
        }
        Destroy(gameObject);
    }
  }
}
