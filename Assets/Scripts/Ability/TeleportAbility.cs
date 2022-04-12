using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = ("Teleport"), menuName = ("Ability/TeleportAbility"), order = 1)]
public class TeleportAbility : BaseAbility
{
    public GameObject HeliLandingPrefab;

    private AudioSource audioSource;

    protected override void ActivateAbility(GameObject owner)
    {
        base.ActivateAbility(owner);

        var heliZone = FindObjectOfType<HelicopterLandingZone>();

        if (heliZone == null) {

            Instantiate(HeliLandingPrefab, owner.transform.position, Quaternion.identity);

        }
        else {
            if (null == audioSource) {
                audioSource = owner.GetComponentInChildren<AudioSource>();
            }
            audioSource?.PlayOneShot(AudioManager.Instance.teleportSFX);
            owner.transform.position = heliZone.transform.position;

            Destroy(heliZone.gameObject);

        }

        
    }


}
