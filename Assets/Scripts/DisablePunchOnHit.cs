using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePunchOnHit : MonoBehaviour
{
    private HurtBox hurtbox;

    public GameObject clinkEffect;

    // Start is called before the first frame update
    void Start()
    {
        hurtbox = GetComponentInChildren<HurtBox>();
        hurtbox.onHurtBoxStruck += Hurtbox_onHurtBoxStruck;
    }

    private void Hurtbox_onHurtBoxStruck(Attack attack)
    {
        if(attack.attackSource.GetComponent<Player>() != null)
        {
            //Debug.Log("disabling " + attack.gameObject);
            //attack.neutralized = true;
            attack.gameObject.SetActive(false);

            StartCoroutine(ClinkEffect());

        }   
    }

    IEnumerator ClinkEffect()
    {
        clinkEffect?.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        clinkEffect?.SetActive(false);
    }

}
