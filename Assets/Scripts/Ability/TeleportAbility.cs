using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = ("Teleport"), menuName = ("Ability/TeleportAbility"), order = 1)]
public class TeleportAbility : BaseAbility
{
    public GameObject HeliLandingPrefab;

    protected override void ActivateAbility(GameObject owner)
    {
        base.ActivateAbility(owner);

        var heliZone = FindObjectOfType<HelicopterLandingZone>();

        if (heliZone == null) 
        {

            Instantiate(HeliLandingPrefab, owner.transform.position, Quaternion.identity);

        }
        else
        {

            owner.transform.position = heliZone.transform.position;

            Destroy(heliZone.gameObject);

        }

        
    }


}
