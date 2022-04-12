using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BaseAbility : ScriptableObject
{
    public float cooldown = 1;




    public void UseAbility(GameObject owner)
    {

        ActivateAbility(owner);
        

    }

    protected virtual void ActivateAbility(GameObject owner)
    {

    }
}
