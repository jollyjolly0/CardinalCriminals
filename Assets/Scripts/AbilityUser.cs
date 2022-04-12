using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUser : MonoBehaviour
{
    public BaseAbility ability;

    string inputButton;

    private void Awake()
    {
        inputButton = "Ability" + GetComponent<Player>().playerNumber.ToString();
    }

    private void Update()
    {
        if (Input.GetButtonDown(inputButton))
        {
            ability?.UseAbility(gameObject);
            if (!ability) { Debug.LogWarning("no ability bound"); }
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
