using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Attack))]
public class EnemyAttackDirection : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Attack attack;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        attack = GetComponent<Attack>();

    }

    private void Update()
    {
        attack.direction = rigid.velocity.normalized;
    }


}
