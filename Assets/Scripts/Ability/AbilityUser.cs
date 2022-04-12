using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUser : MonoBehaviour
{
    public BaseAbility[] ability;
    private float[] lastUsedAt;// = Mathf.NegativeInfinity;
    string inputButtonA;
    string inputButtonB;

    Health health;

    private void Awake()
    {
        inputButtonA = "AbilityA" + GetComponent<Player>().playerNumber.ToString();
        inputButtonB = "AbilityB" + GetComponent<Player>().playerNumber.ToString();

        health = GetComponent<Health>();

        for (int i = 0; i < 2; i++)
        {
            lastUsedAt[i] = Mathf.NegativeInfinity;

        }
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

   
    private void TryUseAbility(int abilitynum)
    {
        if (Time.time > lastUsedAt[abilitynum] + ability[abilitynum].cooldown)
        {
            lastUsedAt[abilitynum] = Time.time;

            ability[abilitynum]?.UseAbility(gameObject);
        }
     }




}
