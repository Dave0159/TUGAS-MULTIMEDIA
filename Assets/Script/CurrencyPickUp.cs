using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//CurrencyPickup
public class CurrencyPickUp : MonoBehaviour
{
    public enum PickupObject {COIN, GEM};
    public PickupObject currentObject;
   public int pickupQuantity;

   void OnTriggerEnter2D(Collider2D other)
   {
    if(other.name == "Player")
    {
        PlayerStat.playerStat.AddCurrency(this);
        Destroy(gameObject);
    }
   }

}
