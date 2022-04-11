using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttackTimer : MonoBehaviour
{
    public float attackInterval = 1.5f;
    public float activeDuration = 0.05f;

    public GameObject basicAttack;


    private void Start()
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
        while (true)
        {

            basicAttack.SetActive(false);
            yield return new WaitForSeconds(attackInterval - activeDuration);

            basicAttack.SetActive(true);

            yield return new WaitForSeconds(activeDuration);

            basicAttack.SetActive(false);

        }

    }


}
