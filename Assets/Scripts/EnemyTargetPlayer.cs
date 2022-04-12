using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Health))]
public class EnemyTargetPlayer : EnemyTarget
{
    private Health health;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
    }

    public override bool IsTargetable()
    {
        return health.isAlive;
    }

}
