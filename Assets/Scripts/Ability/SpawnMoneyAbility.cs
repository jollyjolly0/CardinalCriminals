using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = ("SpawnMoneybag"), menuName = ("Ability/SpawnMoneybagAbility"), order = 1)]
public class SpawnMoneyAbility : BaseAbility
{
    public GameObject moneybagPrefab;

    protected override void ActivateAbility(GameObject owner)
    {
        var hideout = Instantiate(moneybagPrefab, owner.transform.position, Quaternion.identity);
    }
}
