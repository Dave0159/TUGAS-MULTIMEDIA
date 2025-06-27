using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public GameObject fireSpell;
    public GameObject windSpell;

    private GameObject currentSpell;
    private int currentSpellIndex;

    public float switchCooldown;
    private float lastSwitchTime;

    public GameObject CurrentSpell => currentSpell;
    public string CurrentSpellName => (currentSpellIndex == 0) ? "Fire" : "Wind";

    void Start()
    {
        SwitchSpell(0); // Mulai dari spell api
    }

    void Update()
    {
        if (Time.time - lastSwitchTime >= switchCooldown)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchSpell(0);
            else if (Input.GetKeyDown(KeyCode.Alpha2)) SwitchSpell(1);
        }
    }

    void SwitchSpell(int index)
    {
        currentSpellIndex = index;
        lastSwitchTime = Time.time;

        currentSpell = (index == 0) ? fireSpell : windSpell;
        Debug.Log($"Spell saat ini: {(index == 0 ? "Fire" : "Wind")}");
    }

    public float GetCooldownProgress()
    {
        float elapsed = Time.time - lastSwitchTime;
        return Mathf.Clamp01(1f - (elapsed / switchCooldown));
    }
}
