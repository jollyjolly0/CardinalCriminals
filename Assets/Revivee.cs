using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Revivee : MonoBehaviour
{
    float revivePercent;
    public Image reviveMeter;
    Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
        reviveMeter.enabled = false;
    }

    private void Start()
    {
        health.onDeath += OnDeath;
        health.onRevive += OnRevive;
    }

    void OnDeath()
    {
        revivePercent = 0f;
        reviveMeter.enabled = true;
    }
    void OnRevive()
    {
        revivePercent = 0f;
        reviveMeter.enabled = false;
    }
    private void Update()
    {
        if(!health.isAlive)
        {
            reviveMeter.fillAmount = revivePercent;
            if(revivePercent >= 1f)
            {
                health.Revive();
            }
        }
    }
    public void ReviveAmount(float percentPerSecond)
    {
        float amount = percentPerSecond * Time.deltaTime;
        revivePercent += amount;
    }
}
