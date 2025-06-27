using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyReceiveDamage : MonoBehaviour
{
   public float health;
   public float maxhealth;
   
   public GameObject healthBar;
   public Slider healthBarSlider;

   public GameObject lootDrop;

   void Start() 
   {
       health = maxhealth;
       if (healthBarSlider != null) 
       {
           healthBarSlider.value = CalculateHealthPercentage();
       }
   }

   public void DealDamage(float damage)
   {
       healthBar.SetActive(true); 
       health -= damage;
       CheckDeath();
       if (healthBarSlider != null) 
       {
           healthBarSlider.value = CalculateHealthPercentage();
       }
   }

   private void CheckOverheal()
   {
       if (health > maxhealth)
       {
           health = maxhealth;
       }
   }

   private void CheckDeath()
   {
       if (health <= 0)
       {
           Destroy(gameObject);
           Instantiate(lootDrop, transform.position, Quaternion.identity);
       }
   }

   private float CalculateHealthPercentage() // Perbaikan: return nilai
   {
       return health / maxhealth;
   }
}
