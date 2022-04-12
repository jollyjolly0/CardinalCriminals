using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = ("SpawnHideout"), menuName = ("Ability/SpawnHideoutAbility"), order = 1)]
public class SpawnHideoutAbility : BaseAbility
{
    public GameObject hideOutPrefab;
    //public float hideoutDuration;

    protected override void ActivateAbility(GameObject owner)
    {

        var hideout = Instantiate(hideOutPrefab, owner.transform.position, Quaternion.identity);
        //hideout.GetComponent<Hideout>().

    }
}
