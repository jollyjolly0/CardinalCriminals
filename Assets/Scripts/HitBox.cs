using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public Attack attack;

    private void Start()
    {
        attack.attackSource = gameObject.transform.root.gameObject;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        

        var hurtbox = collision.gameObject.GetComponent<HurtBox>();
        if (hurtbox != null)
        {
            //if (collision.transform.parent.gameObject == attack.attackSource) { return; }
            hurtbox.RecieveHit(attack);
        }
    }


}
