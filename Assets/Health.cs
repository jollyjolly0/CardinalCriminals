using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int maxHP;
    public int currentHP;

    public bool isAlive = true;

    public List<DamageSource.Source> vulnerabilities;


    public delegate void OnDeath();
    public event OnDeath onDeath;

    public delegate void OnRevive();
    public event OnRevive onRevive;

    private Dictionary<GameObject, float> recentHitters;
    private float recentHitWindow = 0.1f;


    private void Awake()
    {
        recentHitters = new Dictionary<GameObject, float>();

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
        if (null != dSource && vulnerabilities.Contains(dSource.source))
        {
            if (!WasHitRecently(attack.attackSource))
            {


                AddRecentHit(attack.attackSource);

                Die();
                Debug.Log("FU*K");
            }
        }
    }


    private bool WasHitRecently(GameObject hitter)
    {
        if (!recentHitters.ContainsKey(hitter))
        {
            return false;
        }


        float lastHit = recentHitters[hitter];

        if(Time.time  > recentHitWindow + lastHit)
        {
            return false;
        }


        return true;

    }
    private void  AddRecentHit(GameObject hitter)
    {
        recentHitters[hitter] = Time.time;
    }



    public void Die()
    {
        isAlive = false;
        onDeath?.Invoke();
    }

    public void Revive()
    {
        Debug.Log("Revived");
        isAlive = true;
        onRevive?.Invoke();
    }



}
