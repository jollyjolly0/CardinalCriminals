using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttackTimer : MonoBehaviour
{
    public float attackInterval = 1.5f;
    public float activeDuration = 0.05f;

    public GameObject basicAttack;

    private Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void Start()
    {
        StartAttacking();
        health.onDeath += OnDeath;
        health.onRevive += OnRevive;
    }

    private void OnDeath()
    {
        StopAttacking();
    }
    private void OnRevive()
    {
        StartAttacking();
    }

    void StartAttacking()
    {
        StartCoroutine(AttackRoutine());
    }


    void StopAttacking()
    {
        StopCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        while (health.isAlive)
        {
            basicAttack.SetActive(false);
            yield return new WaitForSeconds(attackInterval - activeDuration);

            basicAttack.SetActive(true);

            yield return new WaitForSeconds(activeDuration);

            basicAttack.SetActive(false);
        }
    }


}
