using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUser : MonoBehaviour
{
    public BaseAbility ability;

    string inputButton;

    Health health;

    private void Awake()
    {
        inputButton = "Ability" + GetComponent<Player>().playerNumber.ToString();

        health = GetComponent<Health>();
    }

    private void Update()
    {
        if (!health.isAlive) { return;  }

        if (Input.GetButtonDown(inputButton))
        {
            TryUseAbility();
        }
    }

    private float lastUsedAt = Mathf.NegativeInfinity;
    private void TryUseAbility()
    {
        if (Time.time > lastUsedAt + ability.cooldown)
        {
            lastUsedAt = Time.time;

            ability?.UseAbility(gameObject);
            if (!ability) { Debug.LogWarning("no ability bound"); }
        }
     }




}
