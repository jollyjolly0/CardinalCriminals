using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{

    public event OnHitEvent onHurtBoxStruck;

    public void RecieveHit(Attack attack)
    {
        onHurtBoxStruck?.Invoke(attack);
    }



}
