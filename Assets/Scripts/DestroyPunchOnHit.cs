using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPunchOnHit : MonoBehaviour
{
    private HurtBox hurtbox;

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
            attack.gameObject.SetActive(false);
        }   
    }
}
