using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int maxHP;
    public int currentHP;

    public bool isAlive;

    public List<DamageSource.Source> vulnerabilities;


    public delegate void OnDeath();
    public event OnDeath onDeath;


    private void Awake()
    {
        var hurtboxes = GetComponentsInChildren<HurtBox>();

        foreach (var box in hurtboxes)
        {
            box.onHit += Box_onHit;
        }

        if(hurtboxes.Length == 0)
        {
            Debug.LogWarning("Did you forget to add a hurtbox to me?");
        }
    }

    private void Box_onHit(Attack attack)
    {

        DamageSource dSource = attack.attackSource.GetComponent<DamageSource>();
        if (null != dSource)
        {
            if (vulnerabilities.Contains(dSource.source))
            {
                Die();
                Debug.Log("FU*K");
            }
        }
    }

    public void Die()
    {
        isAlive = false;
        onDeath.Invoke();
    }



}
