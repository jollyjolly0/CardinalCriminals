using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Revivee : MonoBehaviour
{
    float revivePercent;
    public float reviveDecayRate;
    public Image reviveMeter;
    Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
        reviveMeter.enabled = false;
    }

    void OnDeath()
    {
        reviveMeter.enabled = true;
    }
    void OnRevive()
    {
        reviveMeter.enabled = false;
    }
    private void Update()
    {
        if(!health.isAlive)
        {
            reviveMeter.fillAmount = revivePercent;
        }
    }


}
