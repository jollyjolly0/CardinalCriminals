using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUser : MonoBehaviour
{
    public BaseAbility[] ability;

    string inputButtonA;
    string inputButtonB;

    public float abilityCDModifier = 1f;

    Health health;

    private void Awake()
    {
        inputButtonA = "AbilityA" + GetComponent<Player>().playerNumber.ToString();
        inputButtonB = "AbilityB" + GetComponent<Player>().playerNumber.ToString();

        health = GetComponent<Health>();
    }

    private void Update()
    {
        if (!health.isAlive) { return;  }

        if (Input.GetButtonDown(inputButtonA))
        {
            TryUseAbility(0);
        }
        if (Input.GetButtonDown(inputButtonB))
        {
            TryUseAbility(1);
        }
    }

    private float lastUsedAt = Mathf.NegativeInfinity;
    private void TryUseAbility(int abilitynum)
    {
        if (Time.time > lastUsedAt + ability[abilitynum].cooldown*abilityCDModifier)
        {
            lastUsedAt = Time.time;

            ability[abilitynum]?.UseAbility(gameObject);
        }
     }




}
