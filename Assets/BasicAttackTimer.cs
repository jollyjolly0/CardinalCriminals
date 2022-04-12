using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttackTimer : MonoBehaviour
{
    public float attackInterval = 1.5f;
    public float activeDuration = 0.05f;

    public GameObject basicAttack;
    public AudioSource audioSource;
    public AudioClip whip;

    private Health health;
    private BasicAttackAimer aimer;

    private void Awake()
    {
        health = GetComponent<Health>();
        aimer = GetComponent<BasicAttackAimer>();
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
            aimer.canAim = true;

            basicAttack.SetActive(false);
            yield return new WaitForSeconds(attackInterval - activeDuration);

            aimer.canAim = false;
            basicAttack.SetActive(true);
            audioSource.PlayOneShot(whip);

            yield return new WaitForSeconds(activeDuration);

            basicAttack.SetActive(false);
        }
    }


}
