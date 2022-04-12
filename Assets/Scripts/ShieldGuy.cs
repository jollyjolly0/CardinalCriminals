using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldGuy : MonoBehaviour
{
    private Health health;

    public Transform shields;
    private void Awake()
    {
        health = GetComponent<Health>();
        health.onHurt += OnHurt;
    }

    private void Start()
    {
        if(UnityEngine.Random.Range(0,2) > 0)
        {
            SetShieldHorizontal();
        }
        else
        {
            SetShieldVertical();
        }
    }

    private void OnHurt(Attack attack)
    {
        RotateShields();
    }

    void SetShieldVertical()
    {
        shields.rotation = Quaternion.AngleAxis(90, Vector3.forward);
    }

    void SetShieldHorizontal()
    {
        shields.rotation = Quaternion.AngleAxis(0, Vector3.forward);
    }

    void RotateShields()
    {
        shields.Rotate(Vector3.forward, 90);
    }

}
