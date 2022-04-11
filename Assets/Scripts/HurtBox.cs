using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{

    public event OnHitEvent onHit;

    public void RecieveHit(Attack attack)
    {
        onHit?.Invoke(attack);
    }



}
