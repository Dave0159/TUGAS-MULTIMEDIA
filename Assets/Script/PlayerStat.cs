using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStat : MonoBehaviour
{
    public static PlayerStat playerStat;
    public GameObject player;
    public Slider healthSlider;
    public Slider manaSlider;
    public float mana;
    public float maxMana;
    public float health;
    public float maxHealth;
    public float manaRegenRate = 0.1f; 
    public float manaRegenInterval = 5f; 
    public int coins;
    public int gems;
    public Text coinsValue;
    public Text gemsValue;
    


    void Awake()
    {
        if (playerStat != null)
        {
            Destroy(playerStat);
        }
        else
        {
            playerStat = this;
        }
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        mana = maxMana;
        health = maxHealth;
        healthSlider.value = 1;
        manaSlider.value = 1;
        StartCoroutine(RegenerateManaOverTime());
    }

    public void ManaCost(float usage)
    {
        if (mana >= usage)
        {
            mana -= usage;
            manaSlider.value = CalculateManaPercentage();
        }
    }

    public void RegenerateMana(float amount)
    {
        mana += amount;
        CheckOverMana();
        manaSlider.value = CalculateManaPercentage();
    }

    IEnumerator RegenerateManaOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(manaRegenInterval);
            RegenerateMana(maxMana * manaRegenRate);
        }
    }

    public void ChangeHealth(float amount)
{
    health += amount;
    
    if (amount < 0)
    {
        CheckDeath();
    }
    else
    {
        CheckOverheal();
    }

    healthSlider.value = CalculateHealthPercentage();
}


    private void SetHealthUI()
    {
        healthSlider.value = CalculateHealthPercentage();
    }

    private void CheckOverheal()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private void CheckOverMana()
    {
        if (mana > maxMana)
        {
            mana = maxMana;
        }
    }

    private void CheckDeath()
{
    if (health <= 0)
    {
        health = 0;

        if (player != null)
        {
            Destroy(player);
        }

        // Load the Main Menu (scene 0) on death
        SceneManager.LoadScene(0);
    }
}


    float CalculateHealthPercentage()
    {
        return health / maxHealth;
    }

    float CalculateManaPercentage()
    {
        return mana / maxMana;
    }

     public void AddCurrency(CurrencyPickUp currency)
    {
        if(currency.currentObject == CurrencyPickUp.PickupObject.COIN)
        {
            coins += currency.pickupQuantity;
            coinsValue.text = coins.ToString();
        }
        else if(currency.currentObject == CurrencyPickUp.PickupObject.GEM)
        {
            gems += currency.pickupQuantity;
            gemsValue.text = "Gems : " + gems.ToString();

        }
    }
}
